using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float MaxTime;
    public Text text_Timer;

    // Update is called once per frame
    void Update()
    {
        MaxTime += Time.unscaledDeltaTime;
        text_Timer.text = Mathf.Round(MaxTime) + "초 버팀";
    }
}
