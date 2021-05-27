using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfiguration : MonoBehaviour
{
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public string PlayerType { get; set; }
    public PlayerInfo Info { get; set; } // used to store health and inventory etc

    //public Material PlayerMaterial { get; set; }

    public PlayerConfiguration(PlayerInput playerInput)
    {
        PlayerIndex = playerInput.playerIndex;
        Input = playerInput;
        Info = new PlayerInfo();
    }
}