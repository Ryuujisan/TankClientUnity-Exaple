using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [HideInInspector]
    public GUIMenager gui;

    private Dictionary<int, Tank> playerList = new Dictionary<int, Tank>();
    private Tank localPlayer;


    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        if (GameManager.GamePlay == null)
        {
            GameManager.GamePlay = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerInRoom(List<Protocol.PlayerJoined> players, int localId)
    {
        for (int i = 0; i < players.Count; i++)
        {
            Tank tank = GameManager.PoolMenager.PLayerPool.GetPool(players[i].id);
            tank.id = players[i].id;
            tank.name = players[i].name;

            playerList.Add(tank.id, tank);

            FallowText fallowText = GameManager.PoolMenager.FallowTextPool.GetPool();
            fallowText.SetText(tank.name, tank.transform.position, tank.id);
        }

        localPlayer = playerList[localId];
        gui.LeaderBoard.UpdateScore();
    }

    public void PlayerJoin(Protocol.PlayerJoined playerJoin)
    {
        Tank tank = GameManager.PoolMenager.PLayerPool.GetPool(playerJoin.id);

        tank.id = playerJoin.id;
        tank.name = playerJoin.name;


        FallowText fallowText = GameManager.PoolMenager.FallowTextPool.GetPool();
        fallowText.SetText(tank.name, tank.transform.position, tank.id);

        gui.PlayerJoin(name);
        gui.LeaderBoard.UpdateScore();
    }

    public void PlayerLeafe(int id)
    {
        GameManager.PoolMenager.PLayerPool.ReturnPool(id);


        gui.PlayerLeafe(playerList[id].name);
        playerList.Remove(id);
        gui.LeaderBoard.UpdateScore();
    }

    public void UpdatePlayer(List<Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {

            playerList[players[i].id].SetNewPosition(players[i].position, players[i].course, players[i].barrelCourse);
            playerList[players[i].id].hp = players[i].hp;

        }
    }

    public void Dead()
    {
        gui.LeaderBoard.UpdateScore();
    }

    public Tank LocalPlayer
    {
        get { return localPlayer; }
    }

    public Dictionary<int, Tank> PlayerList
    {
        get { return playerList; }
    }
}
