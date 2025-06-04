using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public float timeBetweenEating;
    public Player player;
    private bool play = false;
    private bool play2 = false;
    public Image h1;
    public Image h2;
    public Image h3;
    public Image h4;
    public Image h5;
    public Image h6;
    public Image h7;
    public Image h8;
    public Image h9;
    public Image h10;
    public Image h11;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenEating += Time.deltaTime;

        if(timeBetweenEating >= 90) {
            if (play == false)
            {
                player.hunger -= 1;
                h1.enabled = false;
                timeBetweenEating = 0;
                play = true;
            }
        }
        
        if(timeBetweenEating >= 90 && player.hunger == 10)
        {
           
                h2.enabled = false;
                timeBetweenEating = 0;
                play2 = true;
                player.hunger -= 1;
            
        }
        if(timeBetweenEating >= 90 && player.hunger == 9)
        {
            h3.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if(timeBetweenEating >= 90 && player.hunger == 8)
        {
            h4.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 7)
        {
            h5.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
            Debug.Log("worked");
            
        }
        if (timeBetweenEating >= 90 && player.hunger == 6)
        {
            h6.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 5)
        {
            h7.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 4)
        {
            h8.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 3)
        {
            h9.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 2)
        {
            h10.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if (timeBetweenEating >= 90 && player.hunger == 1)
        {
            h11.enabled = false;
            timeBetweenEating = 0;
            player.hunger -= 1;
        }
        if(player.hunger == 11) { h1.enabled = true; }
        if (player.hunger >= 10) { h2.enabled = true; }
        if (player.hunger >= 9) { h3.enabled = true; }
        if (player.hunger >= 8) { h4.enabled = true; }
        if (player.hunger >= 7) { h5.enabled = true; }
        if (player.hunger >= 6) { h6.enabled = true; }
        if (player.hunger >= 5) { h7.enabled = true; }
        if (player.hunger >= 4) { h8.enabled = true; }
        if (player.hunger >= 3) { h9.enabled = true; }
        if (player.hunger >= 2) { h10.enabled = true; }
        if(player.hunger >= 1) { h11.enabled = true; }

        if (player.hunger == 0)
        {
            player.health -= Time.deltaTime;
        }
    }
}
