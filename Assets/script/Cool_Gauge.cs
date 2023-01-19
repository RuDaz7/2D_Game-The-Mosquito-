using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Cool_Gauge : MonoBehaviour
{
   public static Image CoolGaugeBar;
    public static bool CoolMode;

    void Start()
    {
        CoolGaugeBar = GetComponent<Image>();
        CoolGaugeBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.CoolMode_On == false) //쿨 모드가 켜졌을 때 만
        {
            if(CoolGaugeBar.fillAmount <= 1.0f) //1보다 작으면 채워짐
            {
            CoolGaugeBar.fillAmount = DateManager.Instance.DiePoints;
            Debug.Log("킬 수" + DateManager.Instance.DiePoints);

            if(CoolGaugeBar.fillAmount >= 1.0f) //1보다 커지면
            {
            CoolMode = true; //쿨모드 조건 달성
            }
            }
        }
        if(Player.CoolMode_On == true) //쿨 모드겨 켜졌을 때 만
        {
            CoolMode = false; //쿨모드 조건 초기화 시키고, 중복으로 켜질 수 있으니까 
            CoolGaugeBar.fillAmount = 0; //쿨타임 게이지 초기화 시키고
        }
    }
}
