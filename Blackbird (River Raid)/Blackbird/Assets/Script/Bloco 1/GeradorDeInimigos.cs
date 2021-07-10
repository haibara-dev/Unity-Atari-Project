using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    public GameObject[] Inimigos;
    public Transform player;
    public float TempodeRespawn = 1.0f;
    public Vector2 screenbounds;
    private bool started = false;

    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));    
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(Inimigos[Random.Range(0, Inimigos.Length)]) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenbounds.x, screenbounds.x), player.position.y + Random.Range(10, 15));
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(TempodeRespawn);
            spawnEnemy();
        }
    }
    private void Update()
    {
        transform.position = new Vector3(0f, player.position.y, 0f);
    }
    public void OnStart()
    {
        started = true;
        StartCoroutine(enemyWave());
    }
}
