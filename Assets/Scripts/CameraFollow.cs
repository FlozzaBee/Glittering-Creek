using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sets the camera to follow the player character in one or both axis
public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public bool followX, followY;

    private Vector3 initialPosition;

    private void Update()
    {
        if (followX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        if (followY)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
