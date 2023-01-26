using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    public int ScorePoints;
    public float DiePoints;
    public float TimeOut;
    private static DateManager instance = null; //싱글톤을 만들기 위해선 스태틱 + 스크립트 이름 앞에 인스턴스를 붙여줌
    public static float CoolTime = 10f;
    //public쓰면 되지만 보안이 취약해짐으로 private으로 써보자.
    public static DateManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Update() 
    {
        Debug.Log("획득한 코인 갯수" + MosqCoin.MosqCoins);

        TimeOut += Time.deltaTime;
        if(TimeOut > 10)
        {
            TimeOut = 0;
            ScorePoints += 1;
        }

        if(Player.CoolMode_On == true)
        {
            CoolTime -= Time.deltaTime;
            Debug.Log("남은 지속시간" + CoolTime);
        }
    }
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this; //자신을 넣어줘라
            
            DontDestroyOnLoad(this.gameObject); //씬 전환되도 파괴안됨
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Score()
    {
        
    }
    public void Die()
        {
         DiePoints = 0;
        }
}
