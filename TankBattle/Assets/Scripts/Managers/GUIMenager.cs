using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIMenager : MonoBehaviour
{
    [SerializeField]
    private Transform viewFinder;

    [SerializeField]
    private LeaderBoard leadBoard;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject Leave;

    [SerializeField]
    private GameObject Respawn;

    [SerializeField]
    private Text info;

    [SerializeField]
    private Image hpBar;

    // Use this for initialization
    void Start()
    {
        GameManager.GamePlay.gui = this;
    }

    // Update is called once per frame
    void Update()
    {
        ControlViewfinder();
    }

    private void HP()
    {
        hpBar.fillAmount = 100f / GameManager.GamePlay.LocalPlayer.hp;
    }

    private void ControlViewfinder()
    {
        viewFinder.rotation = Quaternion.Euler(0f, 0f, GameManager.GamePlay.LocalPlayer.BarrelCourse * Mathf.Rad2Deg);
    }

    public void PlayerJoin(string name)
    {
        info.text = "Player Join " + name;
        info.gameObject.SetActive(true);
        Invoke("deActiv", 2);
    }

    public void PlayerLeafe(string name)
    {
        info.text = "Player Leafe " + name;
        info.gameObject.SetActive(true);
        Invoke("deActiv", 2);
    }

    public void MenuClick()
    {
        menu.gameObject.SetActive(true);
        Leave.gameObject.SetActive(true);
    }

    public void LeaveClick()
    {
        Protocol.Packet packet = new Protocol.Packet();
        packet.leaveGame = new Protocol.LeaveGame();

        GameManager.PacketHandler.ConstructPacket(packet);

        SceneManager.LoadSceneAsync(0);

        GameManager.PoolMenager.Clear();
        GameManager.GamePlay.PlayerList.Clear();
    }

    public void RespawnClick()
    {
        Protocol.Packet Respawn = new Protocol.Packet();
        Respawn.respawn = new Protocol.Respawn();

        GameManager.PacketHandler.ConstructPacket(Respawn);
    }

    public void deActiv()
    {
        info.gameObject.SetActive(false);
    }

    public LeaderBoard LeaderBoard
    {
        get { return leadBoard; }
    }
}
