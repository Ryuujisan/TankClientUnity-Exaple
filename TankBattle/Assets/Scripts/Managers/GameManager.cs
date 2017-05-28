using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static EventManager EventManager;

    public static WebSocketServer Server;
    public static PacketHandler PacketHandler;
    public static PoolMenager PoolMenager;
    public static GamePlay GamePlay;

    private bool lastInternetConnection = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(CheckInternetConnection());
    }

    public static bool IsInternetConnection()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }

    private IEnumerator CheckInternetConnection()
    {
        while (true)
        {
            bool currentConnection = IsInternetConnection();
            if (lastInternetConnection != currentConnection)
            {
#if DEBUG_LOG
                Debug.Log(string.Format("[Internet Connection] Status: {0}", currentConnection));
#endif

                lastInternetConnection = currentConnection;
                EventManager.Dispatch(EventManager.INTERNET_CONNECTION_CHANGED_EVENT);
            }

            yield return new WaitForSeconds(Config.CheckInternetConnectionDelay);
        }
    }
}
