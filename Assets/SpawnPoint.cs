using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Player = this.gameObject.transform.position;
    }
}
