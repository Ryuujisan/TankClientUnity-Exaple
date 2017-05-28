using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour // [Code Review] chyba PlayerPool
{
    [SerializeField]
    private GameObject playerShipPrefab;

    private List<Tank> playerShips = new List<Tank>();

    private int countPool = 64;

    void Awake()
    {
        for (int i = 0; i < countPool; i++)
        {
            GameObject temp = Instantiate(playerShipPrefab) as GameObject;
            temp.transform.SetParent(this.transform);
            temp.transform.localScale = new Vector3(1.0f, 1.0f, 0);

            Tank tempScript = temp.GetComponent<Tank>();

            if (tempScript != null)
            {
                playerShips.Add(tempScript);
            }

            temp.SetActive(false);
        }
    }

    private void ExtendPool()
    {
        //TODO: na później
    }

    public Tank GetPool(int id)
    {
        Tank playerShip = playerShips[id];
        playerShip.gameObject.SetActive(true);

        return playerShip;
    }

    public void ReturnPool(int id)
    {
        playerShips[id].gameObject.SetActive(false);
    }

    public void Clear()
    {
        foreach (Tank ship in playerShips)
        {
            ship.gameObject.SetActive(false);
        }
    }
}
