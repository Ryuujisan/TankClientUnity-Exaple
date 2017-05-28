using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    private Transform localPlayerTransform;

    // Use this for initialization // [Code Review] co to jest ?
    void Start() // [Code Review] co to jest >
    {

    }

    // Update is called once per frame // [Code Review] co to jest ?
    void Update()
    {
        if (localPlayerTransform == null)
        {
            localPlayerTransform = GameManager.GamePlay.LocalPlayer.gameObject.transform; // [Code Review] lepiej tak GameManager.gamePlay.LocalPlayer.PlayerTransform
        }
        else
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, localPlayerTransform.position, 2f);
        }
    }
}
