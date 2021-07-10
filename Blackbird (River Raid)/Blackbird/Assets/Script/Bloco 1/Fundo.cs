using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo : MonoBehaviour
{

    public float velocidade;
    public float limiteY;
    public float posicaoY;

    void Update()
    {
        // MOVE O FUNDO NA DIRECAO (DOWN)
        transform.Translate(Vector2.down * velocidade * Time.deltaTime);

        // VERIFICA SE CHEGOU NO LIMITE
        if(transform.position.y < limiteY)
        {
            transform.position = new Vector2(transform.position.x, posicaoY);
        }

    }
}
