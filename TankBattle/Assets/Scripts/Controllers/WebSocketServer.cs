using System;
using BestHTTP;
using BestHTTP.WebSocket;
using UnityEngine;
//using BestHTTP.WebSocket.Frames;

public class WebSocketServer : MonoBehaviour
{
    private WebSocket webSocket;
    private bool closeRequest = false;

    void Awake()
    {
        if (GameManager.Server == null)
        {
            GameManager.Server = this;
            Connect("ws://localhost:3939");
        }
    }

    public void Connect(string ip)
    {
        CreateWebSocket(ip);
    }

    public void CustomConnectToServer(string url)
    {
        webSocket = null;

        CreateWebSocket(url);
    }

    public bool IsConnected()
    {
        return (webSocket != null) && webSocket.IsOpen;
    }

    public void SendPacket(byte[] packet)
    {
        if (IsConnected() && !closeRequest)
        {
            webSocket.Send(packet);
        }
    }

    public void Close()
    {
        if (webSocket != null)
        {
            closeRequest = true;
            webSocket.Close();

#if DEBUG_LOG
            Debug.LogWarning("[WebSocket Server] Web Socket Closed Invoked");
#endif
        }
    }

    private void Clear()
    {
        closeRequest = false;
        webSocket = null;
    }

    private void CreateWebSocket(string ip)
    {
        if (webSocket != null)
        {
            return;
        }

        webSocket = new WebSocket(new Uri(ip));

#if !UNITY_WEBGL
        if (HTTPManager.Proxy != null)
        {
            webSocket.InternalRequest.Proxy = new HTTPProxy(HTTPManager.Proxy.Address, HTTPManager.Proxy.Credentials, false);
        }
#endif

        webSocket.OnOpen += OnWebSocketOpen;
        webSocket.OnMessage += OnWebSocketMessageReceived;
        webSocket.OnBinary += OnWebSocketBinaryMessageReceived;
        webSocket.OnClosed += OnWebSocketClosed;
        webSocket.OnError += OnWebSocketError;
        webSocket.OnErrorDesc += OnWebSocketErrorDesc;
        //webSocket.OnIncompleteFrame += OnWebSocketIncompleteFrame;

        webSocket.Open();
    }

    private void OnWebSocketOpen(WebSocket ws)
    {
        if (webSocket != null)
        {
#if DEBUG_LOG
            Debug.Log(string.Format("[WebSocket Server] WebSocket Open | {0}", webSocket.IsOpen));
#endif

            GameManager.EventManager.Dispatch(EventManager.WEBSOCKET_OPEN_EVENT);
        }
    }

    private void OnWebSocketMessageReceived(WebSocket ws, string message)
    {
#if DEBUG_LOG
        Debug.Log(string.Format("[WebSocket Server] Message received | {0}", message));
#endif
    }

    private void OnWebSocketBinaryMessageReceived(WebSocket ws, byte[] message)
    {
        if (closeRequest)
        {
            return;
        }

#if DEBUG_LOG
        Debug.Log(string.Format("[WebSocket Server] Binary Message Received | Length: {0}", message.Length));
#endif

        GameManager.PacketHandler.HandleServerPacket(message);
    }

    private void OnWebSocketClosed(WebSocket ws, UInt16 code, string message)
    {
        Clear();
        GameManager.EventManager.Dispatch(EventManager.WEBSOCKET_CLOSED_EVENT);

#if DEBUG_LOG
        Debug.Log("[WebSocket Server] WebSocket Closed!");
#endif
    }

    private void OnWebSocketError(WebSocket ws, Exception ex)
    {
        Clear();
        GameManager.EventManager.Dispatch(EventManager.WEBSOCKET_ERROR_EVENT);

#if !UNITY_WEBGL || UNITY_EDITOR
        if (ws.InternalRequest.Response != null)
        {
#if DEBUG_LOG
            string errorMessage = string.Format("[WebSocket Server] WebSocket Error | Status Code from server: {0} and message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
            Debug.LogError(errorMessage);
#endif
        }
#endif

#if DEBUG_LOG
        if (ex != null)
        {
            Debug.LogError(string.Format("[WebSocket Server] WebSocket Error | An error occured: {0}", ex.Message));
        }
#endif
    }

    private void OnWebSocketErrorDesc(WebSocket ws, string error)
    {
#if DEBUG_LOG
        Debug.LogError(string.Format("[WebSocket Server] WebSocket Error Desc | Error: {0}", error));
#endif
    }

    /*
    private void OnWebSocketIncompleteFrame(WebSocket webSocket, WebSocketFrameReader frame)
    {

    }
    */
}
