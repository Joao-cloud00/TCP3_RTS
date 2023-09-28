using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaçãoJogador : MonoBehaviour
{
    RaycastHit hit;
    public Vector3 point;
    public GameObject unidade;
    private string team;
    void Start()
    {
        team = "Vermelha";
        point = gameObject.transform.position;
    }

    void Update()
    {
        if (team == gameObject.tag)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
                {
                    point = hit.point;
                }
            }   
        }
    }

    private void OnMouseDown()
    {
        if(team == gameObject.tag)
        {
            if(gameObject != unidade)
            {
                unidade = this.gameObject;
                point = gameObject.transform.position;
            }
            unidade = this.gameObject;
        }
    }
}
