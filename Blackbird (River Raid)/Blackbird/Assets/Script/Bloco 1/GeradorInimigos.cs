using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    public GameObject[] inimigos;
    public float frequenciaMinima, frequenciaMaxima;
    public float limiteEsquerdo, limiteDireito;

    private void Start()
    {
        StartCoroutine(CriarInimigos(frequenciaMinima, frequenciaMaxima));
    }


    IEnumerator CriarInimigos(float min, float max)
    {
       
        yield return new WaitForSeconds(Random.Range(min, max));
        GameObject inimigoAtual = Instantiate(inimigos[Random.Range(0, inimigos.Length)]);
        float posX = Random.Range(limiteEsquerdo, limiteDireito);
        inimigoAtual.transform.position = new Vector2(posX, transform.position.y);
        StartCoroutine(CriarInimigos(min, max));
    }

}

