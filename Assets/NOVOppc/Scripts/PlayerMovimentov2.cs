using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovimentov2 : MonoBehaviour
{
    [SerializeField]
    [Range(1, 20)]
    private float speed = 10;

    private Vector3 targetPositiom;
    private bool isMoving;

    const int LEFT_MOUSE_BUTTON = 0;
    const int RIGHT_MOUSE_BUTTON = 1;

    void Start()
    {
        targetPositiom = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
            SetTargetPosition();

        if (isMoving)
            MovePlayer();
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPositiom = ray.GetPoint(point);

        isMoving = true;
    }

    void MovePlayer()
    {
        transform.LookAt(targetPositiom);
        transform.position = Vector3.MoveTowards(transform.position, targetPositiom, speed*Time.deltaTime);

        if(transform.position == targetPositiom)
            isMoving = false;

        Debug.DrawLine(transform.position, targetPositiom, Color.red);
    }
}
