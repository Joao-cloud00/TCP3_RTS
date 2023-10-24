using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomGrid : MonoBehaviour
{
    // Colocar esse script num GameObject vazio chamado Grid

    public int gridSizeX = 10; // Tamanho da grade em X
    public int gridSizeY = 10; // Tamanho da grade em Y
    private Vector3[,] gridPositions; // Matriz para armazenar as posições da grade
    bool botao = false; //bool para permitir/bloquear construçoes pelo botao

    public GameObject prefabQuartel; //prefab de construção
    public GameObject prefabPorto; //idem item acima

    GameObject typeConstruction; // prefab q será instanciado

    public GameObject _gridGame; //GameObjects que serão o Grid no jogo

    void Start()
    {
        // Inicialize a matriz de posições da grade
        gridPositions = new Vector3[gridSizeX, gridSizeY];

        // Preencha a matriz de posições da grade com posições adequadas
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                gridPositions[x, y] = new Vector3(x, 0.5f, y); // Ajuste a altura (Y) conforme necessário
            }
        }    
    }

    private void Update()
    {
        if (botao == true)
        {
            // Verifica se o botão direito do mouse foi clicado
            if (Input.GetMouseButtonDown(1))
            {
                // Lança um raio a partir da posição do cursor do mouse
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Verifica se o raio atingiu algo
                if (Physics.Raycast(ray, out hit))
                {
                    // Verifique se o objeto atingido esta com a tag Grid
                    if (hit.collider.CompareTag("Grid"))
                    {
                        // Obtém a posição do clique em coordenadas de mundo
                        Vector3 clickPosition = hit.point;

                        // Calcula a coordenada (x, y) com base na posição do clique
                        int a = Mathf.FloorToInt(clickPosition.x);
                        int b = Mathf.FloorToInt(clickPosition.z);

                        // print("Posição X: " + a);
                        // print("Posição Y: " + b);

                        // Chama a função para colocar a construção
                        StartCoroutine(ColocarConstrucao(a, b, typeConstruction));
                        print("Bloqueando Construção");
                        _gridGame.SetActive(false);
                        botao = false;

                    }
                }
            }
        }
    }
    public void LiberarQuartel()
    {
        typeConstruction = prefabQuartel;
        _gridGame.SetActive(true);
        print("Liberando Construção de 1 quartel");
        botao = true;
    }
    public void LiberarPorto()
    {
        typeConstruction = prefabPorto;
        _gridGame.SetActive(true);
        print("Liberando Construção de 1 porto");
        botao = true;
    }

    private IEnumerator ColocarConstrucao(int x, int y, GameObject constructionPrefab)
    {
        yield return new WaitForSeconds(3);
        if (x >= 0 && x < gridSizeX && y >= 0 && y < gridSizeY)
        {
            Instantiate(constructionPrefab, gridPositions[x, y], Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Tentativa de colocar construção fora dos limites da grade.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        // Desenhe as linhas horizontais
        for (int x = 0; x < gridSizeX; x++)
        {
            Gizmos.DrawLine(new Vector3(x, 0, 0), new Vector3(x, 0, gridSizeY));
        }

        // Desenhe as linhas verticais
        for (int y = 0; y < gridSizeY; y++)
        {
            Gizmos.DrawLine(new Vector3(0, 0, y), new Vector3(gridSizeX, 0, y));
        }
    }
}

