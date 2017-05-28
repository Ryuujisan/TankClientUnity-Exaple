using UnityEngine;
using UnityEngine.UI;

public class FallowText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Transform transform;

    private Vector3 fallowTransform;

    private Vector3 offset = new Vector3(5714f, 2848f, 0);

    public int id;


    // Update is called once per frame
    void Update()
    {
        fallow();
    }

    public void SetText(string name, Vector3 transform, int id)
    {
        text.text = name;
        fallowTransform = transform;

        Vector3 vector3 = fallowTransform + offset;
        this.transform.position = Camera.main.WorldToViewportPoint(vector3);

        this.id = id;
    }

    private void fallow()
    {
        Vector3 vector3 = fallowTransform + offset;
        transform.position = Camera.main.WorldToViewportPoint(vector3);
    }
}
