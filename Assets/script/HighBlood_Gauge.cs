using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighBlood_Gauge : MonoBehaviour
{
  Image H_BloodGauge;
  public static float HTimer;

   void Start()
    {
        H_BloodGauge = GetComponent<Image>();
        H_BloodGauge.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(H_BloodGauge.fillAmount != 1)
        {
            HTimer = Time.unscaledDeltaTime;
            H_BloodGauge.fillAmount += HTimer * 0.05f;
        }
        
        if(H_BloodGauge.fillAmount == 1)
        {
            Player.HighBlood = true;

            if(Player.HighBlood_On == true)
            {
               Player.HighBlood = false;
               H_BloodGauge.fillAmount = 0;
            }
        }
    }
}
