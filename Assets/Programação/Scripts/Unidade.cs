using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unidade : MonoBehaviour
{
    private Transform posicaoDoTorreInicial;
    public float velocidadeDoInimigo;
    private Vector3 posicaoTorre;
    private MovimentaçãoJogador scriptMov;
    void Start()
    {
        scriptMov = GetComponent<MovimentaçãoJogador>();
        if (gameObject.tag == "Vermelha")
        {
            posicaoDoTorreInicial = GameObject.FindGameObjectWithTag("TorreAzul").transform;
            posicaoTorre = posicaoDoTorreInicial.transform.position;
            posicaoTorre.y = 0.5f;
        }
        if(gameObject.tag == "Azul")
        {
            posicaoDoTorreInicial = GameObject.FindGameObjectWithTag("TorreVermelho").transform;
            posicaoTorre = posicaoDoTorreInicial.transform.position;
            posicaoTorre.y = 0.5f;
        }
    }

    void Update()
    {
        SeguirJogador();
    }

    private void SeguirJogador()
    {
        if(this.gameObject == scriptMov.unidade)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, scriptMov.point, velocidadeDoInimigo * Time.deltaTime);
            //if (posicaoDoTorreInicial.gameObject != null)
            //{
            //}
        }
    }
}
