using UnityEngine;

public class GUIMenager : MonoBehaviour
{
    [SerializeField]
    private Transform viewFinder;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlViewfinder();
    }

    private void ControlViewfinder()
    {
        viewFinder.rotation = Quaternion.Euler(0f, 0f, GameManager.GamePlay.LocalPlayer.BarrelCourse * Mathf.Rad2Deg);
    }
}
