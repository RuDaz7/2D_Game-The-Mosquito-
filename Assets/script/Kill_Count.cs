using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Count : MonoBehaviour
{
   public float Kill_Score;
    public Text Kill;

    // Update is called once per frame
    void Update()
    {
        Kill_Score = Mosq.CountDie;
        Kill.text = "잡은 모기" + Mathf.Round(Kill_Score) + "마리";
    }
}
