using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using UnityEngine;

public class Torres : MonoBehaviour
{
    [SerializeField]
    float tempo;
    public int vida = 10;
    Vector3 posicaoSpawn;
    string faccao;
    void Start()
    {
    }

    void Update()
    {
        if (gameObject.tag == "TorreVermelho")
        {
            faccao = "Vermelha";
        }
        if (gameObject.tag == "TorreAzul")
        {
            faccao = "Azul";
        }
        if(vida == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag != faccao && collision.gameObject.tag != "Chao")
        {
            vida -= 1;
        }
    }
}
