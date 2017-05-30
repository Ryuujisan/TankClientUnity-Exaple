using UnityEngine;

public class PoolMenager : MonoBehaviour
{
    [SerializeField]
    private PlayerPool playerPool;

    [SerializeField]
    private FallowTextPool fallowTextPool;

    [SerializeField]
    private BallPool ballPool;


    void Awake()
    {
        if (GameManager.PoolMenager == null)
        {
            GameManager.PoolMenager = this;
        }
    }

    public void Clear()
    {
        playerPool.Clear();

    }

    public PlayerPool PLayerPool
    {
        get { return playerPool; }
    }

    public FallowTextPool FallowTextPool
    {
        get { return fallowTextPool; }
    }

    public BallPool BallPool
    {
        get { return ballPool; }
    }
}
