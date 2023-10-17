using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject TorreVerm, TorreAzul;
    Vector3 posicaoSpawn;
    void Start()
    {
        for (int i = 0; i < 2;i++) 
        {
        int posicaX = Random.Range(53, -53);
        int posicaZ = Random.Range(53, -53);
        posicaoSpawn = new Vector3(posicaX, 2,posicaZ);
        if(i <= 0)
            {
                Instantiate(TorreVerm,posicaoSpawn,Quaternion.identity);
            }
        if(i >= 1)
            {
                Instantiate(TorreAzul, posicaoSpawn,Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }
}
