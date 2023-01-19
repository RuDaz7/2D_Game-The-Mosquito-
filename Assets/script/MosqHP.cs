using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosqHP : MonoBehaviour
{
    Image MosqBackHP;//
    float MosqMaxHP = 50f;//
    public static float Mosq_HP;//
    
    void Start()
    {
        MosqBackHP = GetComponent<Image>();//
        Mosq_HP = MosqMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        MosqBackHP.fillAmount = Mosq_HP / MosqMaxHP;
    }
}
