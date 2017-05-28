using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

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

    public void PlayerList(List<Protocol.PlayerJoined> players, int localId)
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
    }

    public void PlayerJoin(Protocol.PlayerJoined playerJoin)
    {
        Tank tank = GameManager.PoolMenager.PLayerPool.GetPool(playerJoin.id);

        tank.id = playerJoin.id;
        tank.name = playerJoin.name;

        FallowText fallowText = GameManager.PoolMenager.FallowTextPool.GetPool();
        fallowText.SetText(tank.name, tank.transform.position, tank.id);
    }

    public void PlayerLeafe()
    {

    }

    public void UpdatePlayer(List<Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {

            playerList[players[i].id].SetNewPosition(players[i].position, players[i].course, players[i].barrelCourse);

        }
    }

    public Tank LocalPlayer
    {
        get { return localPlayer; }
    }
}
