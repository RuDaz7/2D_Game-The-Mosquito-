using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighBlood_Gauge : MonoBehaviour
{
  Image H_BloodGauge; //UI 이미지
  public static float HTimer; //고혈압 타이머

   void Start()
    {
        H_BloodGauge = GetComponent<Image>(); //이미지 가져옴
        H_BloodGauge.fillAmount = 0; //고혈압 게이지 0으로 시작
    }

    // Update is called once per frame
    void Update()
    {
        if(H_BloodGauge.fillAmount != 1) //고혈압 게이지가 값이 1과 같거나, 아니면
        {
            HTimer = Time.unscaledDeltaTime; //고혈압 변수에 시간을 넣고
            H_BloodGauge.fillAmount += HTimer * 0.05f; //게이지에 값 넣어줌
        }
        
        if(H_BloodGauge.fillAmount == 1) //게이지가 1일 때
        {
            Player.Ican_HighBlood = true; //플레이어 스크립트 고혈압이 활성화됨

            if(Player.HighBlood_On == true) //그걸 켜면
            {
               Player.Ican_HighBlood = false; //다시 켤수없게 활성값꺼주고 
               H_BloodGauge.fillAmount = 0; //다시 0부터 차도록 0으로 초기화
            }
        }
    }
}
