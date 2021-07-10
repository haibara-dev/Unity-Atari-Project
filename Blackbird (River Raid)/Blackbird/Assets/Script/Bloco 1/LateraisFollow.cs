using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateraisFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    public float offSet = 3.0f;

    void Update()
    {
        transform.position = new Vector3(0f, player.position.y, 0f); // Camera follows the player with specified offset position
    }
}
