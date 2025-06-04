using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public Canvas canvas;
    public bool enabledAlready;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
    canvas.enabled = true;
            enabledAlready = true;
            Cursor.lockState = CursorLockMode.None;

           
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enabledAlready == true)
            {

                canvas.enabled = false; enabledAlready = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

       
    }
}
