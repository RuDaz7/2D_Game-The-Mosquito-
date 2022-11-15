using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Ltime;
    public Text text_Timer;

    // Update is called once per frame
    void Update()
    {
        Ltime -= Time.deltaTime;
        text_Timer.text = "½Ã°£: " + Mathf.Round(Ltime);
    }
}
