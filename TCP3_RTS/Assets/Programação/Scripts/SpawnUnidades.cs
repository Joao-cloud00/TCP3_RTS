using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnidades : MonoBehaviour
{
    public GameObject prefab1; // Prefab da unidade 1
    public GameObject prefab1_2; //Prefab da unidade 1.1
    public GameObject spawnPoint1; //spawn da unidade 1

    public GameObject spawnPoint2; //spawn point da unidade 2
    public GameObject prefab2; // Prefab da unidade 2
    public GameObject prefab2_2; // Prefab da unidade 2.2

    // Adicione mais vari�veis de prefab conforme necess�rio

    private GameObject contrucaoSelecionada;

    private void Update()
    {
        // Verifique se o jogador clicou com o bot�o esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Lan�a um raio a partir do ponto do clique do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //verifica se o raio atingiu algo
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("VASCO");
                // Verifique se o objeto atingido � uma constru��o (pode usar outro tipo de verifica��o ao inv�s de Tag)
                if (hit.collider.CompareTag("Construcao")) 
                {
                    contrucaoSelecionada = hit.collider.gameObject;
                    Debug.Log(contrucaoSelecionada.name);
                }
            }
        }

        // Se uma constru��o estiver selecionada e o jogador clicar com a tecla G
        if (contrucaoSelecionada != null && Input.GetKeyDown(KeyCode.G))
        {
            GameObject selectedPrefab = null;
            GameObject spawPointSelected = null;

            // Exemplo de sele��o de prefab com base em algum crit�rio
            if (contrucaoSelecionada.name.Contains("estrutura1"))
            {
                selectedPrefab = prefab1;
                spawPointSelected = spawnPoint1;
            }
            else if (contrucaoSelecionada.name.Contains("estrutura2"))
            {
                selectedPrefab = prefab2;
                spawPointSelected = spawnPoint2;
            }
            // Adicione mais condi��es conforme necess�rio

            if (selectedPrefab != null)
            {

                // Instancie a unidade no ponto de spawn selecionado
                Instantiate(selectedPrefab, spawPointSelected.transform.position, Quaternion.identity);
            }

            // Limpe a sele��o da constru��o
            contrucaoSelecionada = null;
        }

        UnidadeTier2();
    }

    public void UnidadeTier2()
    {
        if (contrucaoSelecionada != null && Input.GetKeyDown(KeyCode.H))
        {
            GameObject selectedPrefab = null;
            GameObject spawPointSelected = null;

            // Exemplo de sele��o de prefab com base em algum crit�rio
            if (contrucaoSelecionada.name.Contains("estrutura1"))
            {
                selectedPrefab = prefab1_2;
                spawPointSelected = spawnPoint1;
            }
            else if (contrucaoSelecionada.name.Contains("estrutura2"))
            {
                selectedPrefab = prefab2_2;
                spawPointSelected = spawnPoint2;
            }
            // Adicione mais condi��es conforme necess�rio

            if (selectedPrefab != null)
            {
                //precisa ajeitar a posi��o do spawn

                // Instancie a unidade no ponto de spawn selecionado
                Instantiate(selectedPrefab, spawPointSelected.transform.position, Quaternion.identity);
            }

            // Limpe a sele��o da constru��o
            contrucaoSelecionada = null;
        }
    }
}   