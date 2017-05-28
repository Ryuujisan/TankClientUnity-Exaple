using UnityEngine;
using UnityEngine.UI;

public class CustomIpConnect : MonoBehaviour
{
    [SerializeField]
    private Text ip;

    public void Connect()
    {
        string url = "ws://" + ip.text + ":3939";
        Debug.Log(url);
        GameManager.Server.CustomConnectToServer(url);
    }

}
