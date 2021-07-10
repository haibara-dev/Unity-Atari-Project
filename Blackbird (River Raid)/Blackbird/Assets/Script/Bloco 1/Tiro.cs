using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(transform.position.y > screenBounds.y + 10f)
        {
            Destroy(this.gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            GamaManager.Instance.Kills += 1;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Gas")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
