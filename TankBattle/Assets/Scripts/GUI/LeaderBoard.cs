using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<Text> textList;

    private int activeText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        bool localPlayerIs = false;

        DesActiveited();
        int i = 0;
        int j = 0;

        List<Tank> playerList = new List<Tank>(GameManager.GamePlay.PlayerList.Values);
        playerList.Sort((a, b) => (b.frag.CompareTo(a.frag)));


        while (i < playerList.Count)
        {
            if (!localPlayerIs)
            {
                localPlayerIs = playerList[i].id == GameManager.GamePlay.LocalPlayer.id;
            }

            if (j >= textList.Count && !localPlayerIs && activeText <= textList.Count)
            {
                i++;
                continue;
            }

            textList[j].text = playerList[i].name + ": " + playerList[i].frag;
            textList[j++].color = playerList[i++].id == GameManager.GamePlay.LocalPlayer.id ? Color.red : Color.white;

        }
    }

    private void DesActiveited()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].gameObject.SetActive(true);
        }

        if (GameManager.GamePlay.PlayerList.Count < textList.Count)
        {
            for (int i = GameManager.GamePlay.PlayerList.Count; i < textList.Count; i++)
            {
                textList[i].gameObject.SetActive(false);
            }
        }

        /*
        if (GameManager.GamePlay.PlayerList.Count < textList.Count)
        {
            int cout = (textList.Count - GameManager.GamePlay.PlayerList.Count) + 1;
            int textCount = textList.Count;
            activeText = cout;

            for (int i = 0; i < cout; i++)
            {
                textList[cout - i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < textList.Count; i++)
            {
                textList[i].gameObject.SetActive(true);
            }
        }*/
    }
}
