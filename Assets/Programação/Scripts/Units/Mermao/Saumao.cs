using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saumao : MonoBehaviour
{
    private int vidaInicial;
    private float DanoAtual;
    private UnitStats stats;
    [SerializeField]
    private int cooldown;
    private void Start()
    {
        stats = GetComponent<UnitStats>();
        vidaInicial = stats.VidaAtual;
        DanoAtual = stats.DanoStats;
        DanoAtual += 15;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CalculoVida();
            stats.GanharVida(vidaInicial);
        }
    }

    void CalculoVida()
    {
        vidaInicial = vidaInicial * (20 / 100);
    }
}
