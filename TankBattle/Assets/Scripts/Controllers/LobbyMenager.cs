using Protocol;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMenager : MonoBehaviour
{
    [SerializeField]
    private GameObject choseShipPanel;

    [SerializeField]
    private Text playerName;

    public void JoinGame(int ship)
    {
        JoinGame joinGame = new JoinGame();

        joinGame.name = playerName.text;

        SceneManager.LoadSceneAsync(1);

        GameManager.PacketHandler.CreateJoinGamePacket(joinGame);
    }
}
