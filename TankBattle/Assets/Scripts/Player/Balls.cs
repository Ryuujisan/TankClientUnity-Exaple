using UnityEngine;


public class Balls : MonoBehaviour
{
    private const float EPSILON = 0.1f;

    [SerializeField]
    private Transform ballTransform;

    [SerializeField]
    private Sprite ballSprite;

    private int id;
    private float range;
    private float velocity;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 velocityVector;
    private Vector3 dir;

    void FixedUpdate()
    {
        // [Code Review] patrz PlayerShip.cs linia 36
        if ((ballTransform.position - startPoint).magnitude <= range)
        {
            ballTransform.position += dir * velocity * Time.fixedDeltaTime;

        }
        else
        {
            //Debug.Log("chowanie sie do puli");
            GameManager.PoolMenager.BallPool.ReturnPool(id);
        }

    }

    public void SetBall(Vector3 startPoint, Vector3 velocity, float range)
    {
        ballTransform.position = startPoint;
        dir = velocity.normalized;
        this.velocity = velocity.magnitude; // [Code Review] jeśli używasz this to wszędzie, bo jakoś w innych miejscach nie widzę

        velocityVector = velocity;
        this.startPoint = startPoint;

        //this.endPoint = endPoint;
        this.range = range;
    }

    public int ID
    {
        set { id = value; }
        get { return id; }
    }
}
