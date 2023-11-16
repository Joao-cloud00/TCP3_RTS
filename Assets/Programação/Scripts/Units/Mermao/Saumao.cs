using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saumao : MonoBehaviour
{
    [SerializeField]
    private float vidaInicial;
    [SerializeField]
    private float vidaChange;
    private float DanoAtual;
    private float DanoInicial;
    private UnitStats stats;
    [SerializeField]
    private float cooldown;
    private bool Iscooldown;
    private void Start()
    {
        stats = GetComponent<UnitStats>();
        vidaInicial = stats.VidaAtual;
        DanoInicial = stats.DanoStats;
        DanoAtual = DanoInicial + 15;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Funcionando");
            CalculoVida();
            CalcularDano();
            Iscooldown = true;
        }
        if(Iscooldown == true)
        {
            cooldown = Time.time;
            if (cooldown > 5) 
            {
                Iscooldown = false;
                cooldown = 0;
                stats.MudarDano(DanoInicial);
            }
        }

    }
    void CalculoVida()
    {
        vidaChange = vidaInicial * (0.2f);
        stats.GanharVida(vidaChange);
    }

    void CalcularDano()
    {
        if( DanoAtual == DanoInicial + 15)
        {
            stats.MudarDano(DanoInicial);
        }
        stats.MudarDano(DanoAtual);
    }
}
