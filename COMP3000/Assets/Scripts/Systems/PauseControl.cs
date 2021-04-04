using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject firstSelected;

    public void PauseGame()
    {
        Debug.Log("pause game run");
        if (!gameIsPaused)
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            //AudioListener.pause = true;

            pauseMenu.SetActive(true);
            pauseMenu.GetComponent<EventSystem>().SetSelectedGameObject(firstSelected);
        }
        else
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            //AudioListener.pause = false;

            pauseMenu.SetActive(false);
        }
    }

    public bool GetStatus()
    {
        return gameIsPaused; 
    }

    public GameObject GetPauseMenu()
    {
        return pauseMenu;
    }
}
