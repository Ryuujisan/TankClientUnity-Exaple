using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private Transform transform;

    [SerializeField]
    private Transform barrelTransform;

    private Vector3 newPosition = Vector3.zero;

    private float newCourse;
    private float newBarrelCorse;

    public int id;
    public string name;
    public int frag;
    public int hp;

    public void SetNewPosition(Vector3 newPosition, float course, float barrelCourse)
    {

        this.newPosition = newPosition;
        this.newCourse = course;
        this.newBarrelCorse = barrelCourse;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // UpdatePosition();
    }

    void FixedUpdate()
    {
        //Debug.Log(newPosition);
        UpdatePosition();
        UpdateBarrel();
    }

    private void UpdatePosition()
    {
        if ((transform.position - newPosition).magnitude < 1000f)
        {
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, newCourse * Mathf.Rad2Deg);
            return;
        }

        transform.position = Vector3.Lerp(barrelTransform.position, newPosition, Time.fixedDeltaTime);
        //transform.position = Vector3.Lerp(newPosition, barrelTransform.position, 7f);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, newCourse * Mathf.Rad2Deg);
    }

    private void UpdateBarrel()
    {
        barrelTransform.rotation = Quaternion.Euler(0f, 0f, newBarrelCorse * Mathf.Rad2Deg);
    }

    public float Course
    {
        get { return newCourse; }
    }

    public float BarrelCourse
    {
        get { return newBarrelCorse; }
    }
}
