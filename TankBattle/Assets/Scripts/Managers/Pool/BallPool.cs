using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    private List<Balls> ballsList = new List<Balls>();
    private Stack<Balls> freeBallas = new Stack<Balls>();

    private Dictionary<int, Balls> allredyUses = new Dictionary<int, Balls>();

    private int countPool = 64;

    void Awake()
    {
        for (int i = 0; i < countPool; i++)
        {
            GameObject temp = Instantiate(ballPrefab) as GameObject;
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(2f, 2f, 0);

            Balls tempScript = temp.GetComponent<Balls>();

            if (tempScript != null)
            {
                ballsList.Add(tempScript);
                freeBallas.Push(tempScript);
            }

            temp.SetActive(false);
        }
    }

    private void ExtendPool()
    {
        //TODO: na później
    }

    public Balls GetPool(int id)
    {
        Balls playerShip = freeBallas.Pop();
        playerShip.ID = id;
        allredyUses.Add(id, playerShip);
        playerShip.gameObject.SetActive(true);

        return playerShip;
    }

    public void ReturnPool(int id)
    {
        if (allredyUses.ContainsKey(id))
        {
            allredyUses[id].gameObject.SetActive(false);

            if (allredyUses.ContainsKey(id))
            {
                freeBallas.Push(allredyUses[id]);
                allredyUses.Remove(id);
            }
        }
    }

    public void Clear()
    {
        foreach (var ball in allredyUses.Values)
        {
            ball.gameObject.SetActive(false);
            freeBallas.Push(ball);
        }

        freeBallas.Clear();
    }
}
