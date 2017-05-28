using Protocol;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private UltimateJoystick moveJoystick;

    [SerializeField]
    private UltimateJoystick barelJoystick;

    private Vector2 oldRotata = new Vector2();
    private Vector2 oldDir = new Vector2();

    PlayerStering playerStering = new PlayerStering();
    Packet packet = new Packet();

    private float timeToShot = 2f;

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (barelJoystick.JoystickPosition.magnitude >= 0.4f)
        {
            playerStering.barrelDirX = barelJoystick.JoystickPosition.x;
            playerStering.barrelDirY = barelJoystick.JoystickPosition.y;

            oldRotata = barelJoystick.JoystickPosition;
        }
        else
        {
            playerStering.barrelDirX = oldRotata.x;
            playerStering.barrelDirY = oldRotata.y;
        }

        if (moveJoystick.JoystickPosition.magnitude >= 0.4f)
        {
            playerStering.dirY = -moveJoystick.JoystickPosition.x;
            playerStering.dirX = -moveJoystick.JoystickPosition.y;
            playerStering.accelerates = true;
            oldDir = moveJoystick.JoystickPosition;
        }
        else
        {
            playerStering.dirX = oldDir.x;
            playerStering.dirY = oldDir.y;
            playerStering.accelerates = false;
        }

        playerStering.accelerates = moveJoystick.JoystickPosition.magnitude >= 0.4f;

        if ((barelJoystick.JoystickPosition.magnitude > 0.2f))
        {
            Invoke("Shot", 2f);
        }

        //playerStering.isShot = moveJoystick.joystick.position.magnitude > 0.2f;
        packet.playerStering = playerStering;
        GameManager.PacketHandler.ConstructPacket(packet);
        packet.playerStering.shot = false;
    }

    public void Shot()
    {
        if ((barelJoystick.JoystickPosition.magnitude < 0.5f))
        {
            return;
        }

        Debug.Log("Strzela");
        PlayerStering playerShot = new PlayerStering();
        playerShot.shot = true;
        packet.playerStering.shot = true;
        Packet shot = new Packet();
        packet.playerStering = playerShot;

        GameManager.PacketHandler.ConstructPacket(shot);

        timeToShot = 2f;
    }
}
