using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;
    private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    // Enable singleton pattern
    // Access from any game object in any scene
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayerType(int index, string type)
    {
        playerConfigs[index].PlayerType = type;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].IsReady = true;

        // Check all players are ready with lambda expression
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void PlayerJoin(PlayerInput playerInput)
    {
        // If player doesn't already exsist
        if (!playerConfigs.Any(playerConfigs => playerConfigs.PlayerIndex == playerInput.playerIndex))
        {
            playerInput.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(playerInput));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

}
