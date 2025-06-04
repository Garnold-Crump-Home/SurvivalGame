using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject player;
    public Player playerPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = Color.red;
            Invoke("Death", 2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
            RenderSettings.fogColor = Color.cyan;
            RenderSettings.fog = false;
        }
    }
    public void Death()
    {
        playerPlayer.health = 0;
    }
}
