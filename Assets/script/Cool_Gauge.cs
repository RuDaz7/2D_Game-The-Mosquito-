using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class Cool_Gauge : MonoBehaviour
{
    Image CoolGaugeBar;
    public static float CoolGauge;
    public static bool CoolMode;

    void Start()
    {
        CoolGaugeBar = GetComponent<Image>();
        CoolGauge = 0;
        CoolGaugeBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CoolGaugeBar.fillAmount == 0)
        {
        CoolGaugeBar.fillAmount = DateManager.Instance.DiePoints * 0.1f;
        }

        if(CoolGaugeBar.fillAmount == 1f)
        {
            CoolMode = true;
        }
    }
}
