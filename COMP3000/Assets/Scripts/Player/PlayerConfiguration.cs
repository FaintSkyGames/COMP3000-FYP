using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfiguration : MonoBehaviour
{
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    [SerializeField]
    public bool IsReady { get; set; }
    [SerializeField]
    public string PlayerType { get; set; }

    //public Material PlayerMaterial { get; set; }

    public PlayerConfiguration(PlayerInput playerInput)
    {
        PlayerIndex = playerInput.playerIndex;
        Input = playerInput;
    }
}