using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    public int Comida = 100;
    void Start()
    {

    }

    void Update()
    {
        text.text = "Comida : " + Comida + " / 100";
    }
}
