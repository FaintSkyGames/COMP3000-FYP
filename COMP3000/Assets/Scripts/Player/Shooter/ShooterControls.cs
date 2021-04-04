using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControls : MonoBehaviour
{
    [SerializeField]
    GameObject selectedWeapon;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            //Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);
        }
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);
    }
}
