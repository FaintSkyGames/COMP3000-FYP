using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HidePlayerType : MonoBehaviour
{
    [SerializeField]
    private EventSystem es;
    [SerializeField]
    private GameObject shooterButton;
    [SerializeField]
    private GameObject shooterText;
    [SerializeField]
    private GameObject puzzleButton;
    [SerializeField]
    private GameObject puzzleText;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(es.currentSelectedGameObject.name);
        if (es.currentSelectedGameObject.name == "Shooter")
        {
            shooterButton.GetComponent<Image>().enabled = true;
            shooterText.GetComponent<Text>().enabled = true;
            puzzleButton.GetComponent<Image>().enabled = false;
            puzzleText.GetComponent<Text>().enabled = false;
        }
        else if (es.currentSelectedGameObject.name == "Puzzle")
        {
            puzzleButton.GetComponent<Image>().enabled = true;
            puzzleText.GetComponent<Text>().enabled = true;
            shooterButton.GetComponent<Image>().enabled = false;
            shooterText.GetComponent<Text>().enabled = false;
        }
    }
}
