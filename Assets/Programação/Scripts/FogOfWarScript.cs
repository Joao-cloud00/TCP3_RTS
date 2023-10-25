using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarScript : MonoBehaviour
{
    public GameObject fogOfWarPlane;
    public Transform player;
    public LayerMask fogLayer;
    public float radius = 5f;
    private float radiusSqr { get { return radius*radius; } }

    private Mesh mesh;
    private Vector3[] vetices;
    private Color[] colors;
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Ray r = new Ray(transform.position, player.position - transform.position);
        RaycastHit hit;
        if(Physics.Raycast(r, out hit, 1000, fogLayer, QueryTriggerInteraction.Collide) ) 
        {
            for(int i = 0; i < vetices.Length; i++)
            {
                Vector3 v = fogOfWarPlane.transform.TransformPoint(vetices[i]);
                float dist = Vector3.SqrMagnitude(v - hit.point);
                if( dist < radiusSqr)
                {
                    float alpha = Mathf.Min(colors[i].a, dist / radiusSqr);
                    colors[i].a = alpha;
                }
            }
            UpdateColor();
        }
    }

    void Initialize()
    {
        mesh = fogOfWarPlane.GetComponent<MeshFilter>().mesh;
        vetices = mesh.vertices;
        colors = new Color[vetices.Length];
        for (int i=0; i<colors.Length; i++)
        {
            colors[i] = Color.black;
        }
        UpdateColor();
    }
    void UpdateColor()
    {
        mesh.colors = colors;
    }
}
