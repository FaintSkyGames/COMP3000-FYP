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
    private GameObject buttonBlue;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(es.currentSelectedGameObject.name);
        if (es.currentSelectedGameObject.name == "Red")
        {
            buttonRed.GetComponent<Image>().enabled = true;
            buttonBlue.GetComponent<Image>().enabled = false;
        }
        else if (es.currentSelectedGameObject.name == "Blue")
        {
            buttonBlue.GetComponent<Image>().enabled = true;
            buttonRed.GetComponent<Image>().enabled = false;
        }
    }
}
