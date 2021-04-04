using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class InitalizeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject shooterPlayerPrefab;
    [SerializeField]
    private GameObject puzzlePlayerPrefab;

    public GameObject playerHUDPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            GameObject player = null;
            if (playerConfigs[i].PlayerType == "Shooter")
            {
                player = Instantiate(shooterPlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            }
            if (playerConfigs[i].PlayerType == "Puzzle")
            {
                player = Instantiate(puzzlePlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            }
            //var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<InputHandler>().InitializePlayer(playerConfigs[i]);

            // Spawn HUD
            var rootMenu = GameObject.Find("HUD Layout");
            if (rootMenu != null)
            {
                var menu = Instantiate(playerHUDPrefab, rootMenu.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
