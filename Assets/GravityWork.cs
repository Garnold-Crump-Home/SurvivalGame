using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWork : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    public bool work;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (player)
        {

           work = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player) { work = true; } 
    }
}
