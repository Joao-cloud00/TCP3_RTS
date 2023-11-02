using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    private Vector3 targetPosition;
    //private bool isMoving = false;
    public float _speed;
    public LayerMask Player;
    public LayerMask Ground;

    private void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, Player))
            {
                if (hit.transform.CompareTag("Unit"))
                {
                    // Selecionar uma unidade
                    SelectUnit(hit.transform);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, Ground))
            {
                SetTargetPosition(hit.point);
            }
        }
    }

    void SelectUnit(Transform unit)
    {
        targetPosition = unit.position;
        //isMoving = true;
        Debug.Log("Unidade selecionada: " + unit.name);
    }

    void SetTargetPosition(Vector3 destination)
    {
        // Define o destino para a unidade selecionada
        targetPosition = destination;
        Debug.Log("Movendo unidade para " + destination);
    }

    private void FixedUpdate()
    {


        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
    }
}
