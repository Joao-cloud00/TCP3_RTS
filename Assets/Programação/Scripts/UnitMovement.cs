using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving = false;
    public float _speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Unit"))
                {
                    // Selecionar uma unidade
                    SelectUnit(hit.transform);
                }
                //else if (hit.transform.CompareTag("Grid") && isMoving)
                //{
                //    // Definir um destino para a unidade selecionada
                //    SetTargetPosition(hit.point);
                //}
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.transform.CompareTag("Unit"))
                //{
                //    // Selecionar uma unidade
                //    SelectUnit(hit.transform);
                //}
                if (hit.transform.CompareTag("Grid") && isMoving)
                {
                    // Definir um destino para a unidade selecionada
                    SetTargetPosition(hit.point);
                }
            }
        }
    }

    void SelectUnit(Transform unit)
    {
        // Verifica se a unidade já está em movimento
        if (isMoving)
        {
            StopMoving();
        }

        targetPosition = unit.position;
        isMoving = true;
        Debug.Log("Unidade selecionada: " + unit.name);
    }

    void SetTargetPosition(Vector3 destination)
    {
        // Define o destino para a unidade selecionada
        targetPosition = destination;
        Debug.Log("Movendo unidade para " + destination);
    }

    void StopMoving()
    {
        // Interrompe o movimento da unidade
        isMoving = false;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move a unidade em direção ao destino
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Chegou ao destino
                StopMoving();
                Debug.Log("Unidade chegou ao destino");
            }
        }
    }
}
