using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Krakinho : MonoBehaviour
{
    private Rigidbody targetPosition;
    public LayerMask Unit;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, Unit))
            {
                if (hit.transform.CompareTag("Unit"))
                {
                    // Selecionar uma unidade
                    SelectUnit(hit.rigidbody);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            targetPosition.GetComponent<UnitStats>().MudarDano(15);
            targetPosition.GetComponent<UnitStats>().UpgradeVelocidade(2);
            targetPosition.GetComponent<UnitStats>().AtualizarArmadura(30);
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            targetPosition.GetComponent<UnitStats>().GanharVida(20);
        }
    }
    void SelectUnit(Rigidbody unit)
    {
        targetPosition = unit;
        //isMoving = true;
        Debug.Log("Unidade selecionada: " + unit.name);
    }
}
