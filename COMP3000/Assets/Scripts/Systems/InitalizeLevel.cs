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

    public GameObject PuzzleHUDPrefab;
    public GameObject shooterHUDPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            var rootMenu = GameObject.Find("HUD Layout");

            // Spawn Player
            GameObject player = null;
            if (playerConfigs[i].PlayerType == "Shooter")
            {
                player = Instantiate(shooterPlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);

                // Spawn HUD
                if (rootMenu != null)
                {
                    Instantiate(shooterHUDPrefab, rootMenu.transform);
                }
            }
            if (playerConfigs[i].PlayerType == "Puzzle")
            {
                player = Instantiate(puzzlePlayerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);

                if (rootMenu != null)
                {
                    var menu = Instantiate(PuzzleHUDPrefab, rootMenu.transform);
                    menu.transform.Find("Inventory").GetComponent<PuzzleInventoryUI>().BindToPlayer(playerConfigs[i]);
                }                
            }
            player.GetComponent<InputHandler>().InitializePlayer(playerConfigs[i]);            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
