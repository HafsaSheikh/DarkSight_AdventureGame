using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        //Make Camera follow the vehical
        //transform.position = player.transform.position;

        //offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;

    }
}
