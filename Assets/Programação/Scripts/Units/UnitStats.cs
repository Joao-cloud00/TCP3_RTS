using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class UnitStats : MonoBehaviour
{
    [SerializeField]
    private int tier;
    [SerializeField]
    private string[] movimentos;
    [SerializeField]
    private int VidaMaxima;
    [SerializeField]
    private float reduzDano;
    [SerializeField]
    private float cooldown = 3;
    public int VidaAtual;
    public int Armadura;
    public float DanoStats;
    public float Dano;
    public int Distancia;
    public int Velocidade;
    public int EspiritualidadeMaxima;
    public float EspiritualidadeAtual;

    private void Start()
    {
        VidaAtual = VidaMaxima;
        EspiritualidadeAtual = EspiritualidadeMaxima;

        movimentos = new string[4];
        movimentos[0] = "Agua";
        movimentos[1] = "Terra";
        movimentos[2] = "Hibridos";
        movimentos[3] = "Ar";
    }

    private void Update()
    {
        if (EspiritualidadeAtual < EspiritualidadeMaxima)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                RecuperarEspiritualidade();
            }
        }
        if (EspiritualidadeAtual == EspiritualidadeMaxima)
        {
            cooldown = 3;
        }
    }

    #region "Vida Stats"

    public void LevarDano(int valorDano)
    {
        VidaAtual -= (valorDano - ((int)reduzDano) / 100);
    }

    public void GanharVida(int valorVida)
    {
        VidaAtual += valorVida;
    }

    public void UpdateVida(int valorUpgrade)
    {
        VidaMaxima += valorUpgrade;
        VidaAtual = VidaMaxima;
    }
    #endregion

    #region "Armadura Stats"

    public void CalculaArmadura()
    {
        if (tier == 1)
        {
            reduzDano = (Armadura * 5) * (1.25f * 1);
        }
        if (tier == 2)
        {
            reduzDano = (Armadura * 5) * (1.25f * 1.25f);
        }
    }

    #endregion

    #region "Dano Stats"

    public void SortDano()
    {
        float randomDano;
        float MaxDano;
        float MinDano;
        MaxDano = (DanoStats * 1.5f) * tier;
        MinDano = (DanoStats * tier);
        randomDano = Random.RandomRange(MinDano, MaxDano);
        Dano = randomDano;
    }


    public void MudarDano(float Dano)
    {
        DanoStats = Dano;
    }




    #endregion

    #region "Distancia Stats"

    //Adicionar um comparador de distancia entre dois objetos
    //Como não há objetos ainda, deixo para depois

    #endregion

    #region "Velocidade Stats"

    public void UpgradeVelocidade(int valorVelocidade)
    {
        Velocidade += valorVelocidade;
    }

    #endregion

    #region "Espiritualidade Stats"

    public void GastarEspiritualidade(int valorHabilidade)
    {
        EspiritualidadeAtual -= valorHabilidade;
    }

    public void RecuperarEspiritualidade()
    {
        EspiritualidadeAtual += Time.deltaTime;
    }

    #endregion
}
