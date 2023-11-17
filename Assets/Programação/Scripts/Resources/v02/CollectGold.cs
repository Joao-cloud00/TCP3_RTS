using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGold : MonoBehaviour
{
    public Text goldText;
    public int gold;

    void Start()
    {

        gold = 0;
        
    }

    void Update()
    {
        goldText.text = gold.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision");
    }
}
