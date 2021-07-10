using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour
{
    public static Controler Instance { set; get; }
    public bool isFlying = false;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 moveVelocity;
    private float velocidade = 3;
    private float lVelocidade = 5;
    public GameObject tiro;

    public bool isGameStarted = false;
    public float Gas;
    public float Consumo = 1f;
    public Slider GasBar;
    public float Kill;
    public int KillTarget;

    public AudioClip[] clips;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Gas = 20f;
        GasBar.value = Gas;
    }
    public void OnStart()
    {
        isFlying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFlying)
            return;
        Kill = GamaManager.Instance.Kills;
        float moverX = Input.GetAxis("Horizontal") * lVelocidade * Time.deltaTime;
        float moverY = velocidade * Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            OnFire();
        }
        transform.Translate(moverX, moverY, 0.0f);

        Gas -= (Time.deltaTime * Consumo);
        GasBar.value = Gas;

        if (Gas >= 20)
        {
            Gas = 20f;
        }
        if (Gas <= 0)
        {
            GetComponent<AudioSource>().clip = clips[2]; // GameOver Gas
            GetComponent<AudioSource>().Play();
            Crash();
        }
        if (Kill >= KillTarget)
        {
            isFlying = false;
        }
    }

    public void OnFinish()
    {
        isFlying = false;
    }

    private void Crash()
    {
        isFlying = false;
        GamaManager.Instance.OnDeath();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<AudioSource>().clip = clips[1]; // GameOver collider
            GetComponent<AudioSource>().Play();
            Crash();
            return;
        }
        if (collision.gameObject.tag == "Gas")
        {
            Gas += 5f;
            GetComponent<AudioSource>().clip = clips[3]; // More gas
            GetComponent<AudioSource>().Play();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gas")
        {
            Destroy(other.gameObject);
        }
    }

    public void OnFire()
    {
        GameObject s = Instantiate(tiro) as GameObject;
        s.transform.position = this.transform.position;
        GetComponent<AudioSource>().clip = clips[0]; // Tiro GunRay
        GetComponent<AudioSource>().Play();
    }
}
