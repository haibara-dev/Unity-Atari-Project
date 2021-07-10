using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopteroDireita : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        if (transform.position.y < -screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }
}
