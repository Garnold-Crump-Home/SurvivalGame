using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
   public bool isColliding = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isColliding=false;
    }
}
