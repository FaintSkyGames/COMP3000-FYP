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
    private GameObject buttonRed;
    [SerializeField]
    private GameObject redText;
    [SerializeField]
    private GameObject buttonBlue;
    [SerializeField]
    private GameObject blueText;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(es.currentSelectedGameObject.name);
        if (es.currentSelectedGameObject.name == "Red")
        {
            buttonRed.GetComponent<Image>().enabled = true;
            redText.GetComponent<Text>().enabled = true;
            buttonBlue.GetComponent<Image>().enabled = false;
            blueText.GetComponent<Text>().enabled = false;
        }
        else if (es.currentSelectedGameObject.name == "Blue")
        {
            buttonBlue.GetComponent<Image>().enabled = true;
            blueText.GetComponent<Text>().enabled = true;
            buttonRed.GetComponent<Image>().enabled = false;
            redText.GetComponent<Text>().enabled = false;
        }
    }
}
