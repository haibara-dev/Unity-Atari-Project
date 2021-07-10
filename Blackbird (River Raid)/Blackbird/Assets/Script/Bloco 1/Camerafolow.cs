using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafolow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float offSet = 3.0f;

    void Update()
    {
        transform.position = new Vector3(0f, player.position.y + offSet, -10f); // Camera follows the player with specified offset position
    }
}
