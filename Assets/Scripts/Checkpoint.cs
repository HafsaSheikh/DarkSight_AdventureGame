using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameVariables.checkpoint = transform.position;
           // Debug.Log("PlayerCollides with checkpoint " + GameVariables.checkpoint);
        }
    }
}
