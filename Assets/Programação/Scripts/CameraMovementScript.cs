using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    public float speed = 0.06f;
    public float zoomSpeed = 10.0f;
    public float rotateSpeed = 0.1f;

    float maxAltura = 20f;
    float minAltura = 4f;

    Vector2 p1;
    Vector2 p2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //velocidade horizontal
        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        //velocidade vertical
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical") * Time.deltaTime;
        //velocidade do zoom
        float scrollSp = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        //limites de altura
        if((transform.position.y >= maxAltura) && (scrollSp > 0))
        {
            scrollSp = 0;
        }
        else if ((transform.position.y <= minAltura) && (scrollSp < 0))
        {
            scrollSp = 0;
        }

        if ((transform.position.y + scrollSp) > maxAltura)
        {
            scrollSp = maxAltura - transform.position.y;
        }
        else if ((transform.position.y + scrollSp) < minAltura)
        {
            scrollSp = minAltura - transform.position.y;
        }

        //limites de rotação Y


        Vector3 verticalMove = new Vector3(0, scrollSp, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;

        getCameraRotation();
    }

    void getCameraRotation()
    {
        if (Input.GetMouseButtonDown(2)) //verifica se o botao do meio é apertado
        {
            p1 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2)) //verifica se o botao do meio está pressionado
        {
            p2 = Input.mousePosition;
            //p1 - p2;
            float dx = (p2 - p1).x * rotateSpeed * Time.deltaTime;
            float dy = (p2 - p1).y * rotateSpeed * Time.deltaTime;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0)); //rotação eixo Y
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy,0,0)); //rotação eixo X

            
        }
    }
}
