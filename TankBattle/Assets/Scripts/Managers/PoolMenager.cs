using UnityEngine;

public class PoolMenager : MonoBehaviour
{
    [SerializeField]
    private PlayerPool playerPool;

    [SerializeField]
    private FallowTextPool fallowTextPool;


    void Awake()
    {
        if (GameManager.PoolMenager == null)
        {
            GameManager.PoolMenager = this;
        }
    }

    public PlayerPool PLayerPool
    {
        get { return playerPool; }
    }

    public FallowTextPool FallowTextPool
    {
        get { return fallowTextPool; }
    }
}
