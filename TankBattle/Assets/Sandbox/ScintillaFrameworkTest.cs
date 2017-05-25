using UnityEngine;
using System.Collections;

public class ScintillaFrameworkTest : MonoBehaviour
{
    [SerializeField]
    private string ip;

    void Start()
    {
        GameManager.EventManager.Add(EventManager.INTERNET_CONNECTION_CHANGED_EVENT, OnInternetConnectionChanged);

        GameManager.EventManager.Add(EventManager.WEBSOCKET_OPEN_EVENT, OnWebSocketOpen);
        GameManager.EventManager.Add(EventManager.WEBSOCKET_CLOSED_EVENT, OnWebSocketClosed);
        GameManager.EventManager.Add(EventManager.WEBSOCKET_ERROR_EVENT, OnWebSocketError);

        if (GameManager.IsInternetConnection() && !GameManager.Server.IsConnected())
        {
            ConnectWithServer();
        }
    }

    void OnDestroy()
    {
        GameManager.EventManager.Remove(EventManager.INTERNET_CONNECTION_CHANGED_EVENT, OnInternetConnectionChanged);

        GameManager.EventManager.Remove(EventManager.WEBSOCKET_OPEN_EVENT, OnWebSocketOpen);
        GameManager.EventManager.Remove(EventManager.WEBSOCKET_CLOSED_EVENT, OnWebSocketClosed);
        GameManager.EventManager.Remove(EventManager.WEBSOCKET_ERROR_EVENT, OnWebSocketError);
    }

    private void ConnectWithServer()
    {
        GameManager.Server.Connect(ip);
    }

    private IEnumerator ReconnectWithServer()
    {
        yield return new WaitForSeconds(Config.ReconnectDelay);
        ConnectWithServer();
    }

    private void OnInternetConnectionChanged()
    {
        if (GameManager.IsInternetConnection())
        {
            StartCoroutine(ReconnectWithServer());
        }
        else
        {
            GameManager.Server.Close();
        }
    }

    private void OnWebSocketOpen()
    {

    }

    private void OnWebSocketClosed()
    {
        if (GameManager.IsInternetConnection())
        {
            StartCoroutine(ReconnectWithServer());
        }
    }

    private void OnWebSocketError()
    {
        if (GameManager.IsInternetConnection())
        {
            StartCoroutine(ReconnectWithServer());
        }
    }
}
