using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuManager : MonoBehaviour
{
    private int playerIndex;

    [SerializeField]
    private Text playerNameText;
    //[SerializeField]
    //private Button readyButton;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;

    private float ignoreInputTime = 0.3f;
    private bool inputEnabled = false;

    public void SetPlayerIndex(int pi)
    {
        playerIndex = pi;
        playerNameText.text = "Player " + (playerIndex + 1).ToString();
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SetType(string type)
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerType(playerIndex, type);
        readyPanel.SetActive(true);
        //readyButton.Select();
        menuPanel.SetActive(false);

        ReadyPlayer();
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        //readyButton.gameObject.SetActive(false);
    }
}
