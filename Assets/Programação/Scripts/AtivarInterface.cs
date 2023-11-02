using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarInterface : MonoBehaviour
{
    public GameObject prefabInterface;
    Vector3 destino;
    Vector3 posInit;

    private void Start()
    {
        posInit = transform.position;
    }

    private void Update()
    {
        // Verifica se o botão direito do mouse foi clicado
        if (Input.GetMouseButtonDown(0))
        {
            // Lança um raio a partir da posição do cursor do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verifica se o raio atingiu algo
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.CompareTag("Unit"))
                {
                    //print("Botao Esquerdo clicado");
                    prefabInterface.SetActive(true);
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            //// Lança um raio a partir da posição do cursor do mouse
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //// Verifica se o raio atingiu algo
            //if (Physics.Raycast(ray, out hit))
            //{
            //    // Verifique se o objeto atingido esta com a tag Grid
            //    if (hit.collider.CompareTag("Placement"))
            //    {
            //        // Obtém a posição do clique em coordenadas de mundo
            //        Vector3 clickPosition = hit.point;

            //        // Calcula a coordenada (x, y) com base na posição do clique
            //        int a = Mathf.FloorToInt(clickPosition.x);
            //        int b = Mathf.FloorToInt(clickPosition.z);

            //        //destino = new Vector3(a+1.5f, 0.5f, b);
            //        //transform.position = destino;
            //    }
            //}
            //print("Botão direito clicado");
            prefabInterface.SetActive(false);
        }

    }
}
