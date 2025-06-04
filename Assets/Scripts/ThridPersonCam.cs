using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCam : MonoBehaviour
{
    public Camera camera;
    public Camera cam2;
    void Start()
    {
        camera.enabled = false;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            camera.enabled = true;
        }
        else { camera.enabled = false; }
        if (Input.GetKey(KeyCode.V))
        {
            cam2.enabled = true;
        }
        else { cam2.enabled = false; }
    }
}
