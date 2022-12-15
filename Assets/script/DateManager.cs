using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    public int ScorePoints;
    public int DiePoints;
    public float TimeOut;
    private static DateManager instance = null; //싱글톤을 만들기 위해선 스태틱 + 스크립트 이름 앞에 인스턴스를 붙여줌
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
        TimeOut += Time.deltaTime;
        if(TimeOut > 10)
        {
            TimeOut = 0;
            ScorePoints += 1;
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
        if(ScorePoints > 10)
        {
            Debug.Log("10포인트 달성");
        }
    }
    public void Die()
        {
         DiePoints = 0;

            if(DiePoints > 10)
        {
            Debug.Log("10킬 달성");
        }
        }
}
