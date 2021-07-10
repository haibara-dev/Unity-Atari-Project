using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance { set; get; }
    public Transform playerTransform;
    public Animator Menu, Finish;
    public bool isGameStarted = false;
    public bool isDead = false;
    private float modifierScore, score;
    private int lastScore;
    public Text scoreText, deadScoreText, KillText;
    public Button StartButton, TryAgainButton, NextLevel;
    public GameObject player;

    public int KillTarget;

    public float Kills;

    private Controler motor;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartButton.gameObject.SetActive(true);
        TryAgainButton.gameObject.SetActive(false);
        //scoreText.gameObject.SetActive(false);
        //deadScoreText.gameObject.SetActive(false);

        Kills = 0;
        KillText.text = Kills.ToString("0");

        NextLevel.gameObject.SetActive(false);
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<Controler>();
    }

    void Update()
    {
        if (!isGameStarted)
            return;

        KillText.text = Kills.ToString("0");

        if (Kills >= KillTarget)
        {
            NextLevel.gameObject.SetActive(true);
            isGameStarted = false;
        }
        if (isGameStarted && !isDead)
        {
            //scoreText.gameObject.SetActive(true);
            score += (Time.deltaTime);
            /*if (lastScore != (int)score)
            {
                lastScore = (int)score;
                scoreText.text = score.ToString("0");
            }*/
        }
    }


    public void OnDeath()
    {
        TryAgainButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        deadScoreText.gameObject.SetActive(true);
        deadScoreText.text = score.ToString("0");

        if (score > PlayerPrefs.GetInt("Hiscore"))
        {
            float s = score;
            if (s % 1 == 0)
                s += 1;
            PlayerPrefs.SetInt("Hiscore", (int)s);
        }
    }
    public void UpdateModifier(float modifierAmount)
    {
        modifierScore = 1.0f + modifierAmount;
    }
    public void OnStart()
    {
        StartButton.gameObject.SetActive(false);
        //scoreText.gameObject.SetActive(true);
        isGameStarted = true;
    }

    public void OnTryAgainButton()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Fase1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
