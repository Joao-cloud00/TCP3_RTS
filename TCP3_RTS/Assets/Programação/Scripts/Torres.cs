using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using UnityEngine;

public class Torres : MonoBehaviour
{
    [SerializeField]
    private Unidade unidadeAzul,unidadeVerm;
    float tempo;
    public int vida = 10;
    Vector3 posicaoSpawn;
    string faccao;
    void Start()
    {
    }

    void Update()
    {
        posicaoSpawn = gameObject.transform.position;
        int aleatorio = Random.Range(3, -3);
        posicaoSpawn.z -= aleatorio;
        posicaoSpawn.x -= aleatorio;
        posicaoSpawn.y = 0.5f;
        tempo += Time.deltaTime;
        if (gameObject.tag == "TorreVermelho")
        {
            faccao = "Vermelha";
            if(tempo >= 4)
            {
                Instantiate(unidadeVerm, posicaoSpawn, Quaternion.identity);
                tempo = 0;
            }
        }
        if (gameObject.tag == "TorreAzul")
        {
            faccao = "Azul";
            if (tempo >= 4)
            {
                Instantiate(unidadeAzul, posicaoSpawn, Quaternion.identity);
                tempo = 0;
            }
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
