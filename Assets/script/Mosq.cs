using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosq : MonoBehaviour
{
    public static bool Boss_HP_Zero = false;
    public ParticleSystem Die_Particle; //모기 사망 임팩트
    Vector3 position; //위치값 받을 벡터 변수
    public Vector3 direction; //방향 변수
    public float velocity; //속도 변수
    public float accelaration; 
    Animator anime;
    SpriteRenderer spriteRenderer;
    GameObject target;
    public AudioClip Die_clip; 
    public float MosqTempHP = 30f;
    public static bool MosqMoveStop = false; //모기 움직임 봉쇄
    public GameObject MosqCoinPre; //가지고올 프리팹
    public ParticleSystem SuperShotDie;
    public static int CountDie;

    void Start()
    {   
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴
        position = transform.position;
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if(MosqMoveStop)
        {
            anime.SetBool("Attack", false);
            this.anime.speed = 0;
            velocity = 0;
            accelaration = 0;
        }
        else this.anime.speed = 1;

        if(Player.HighBlood_On)
        {
            Time.timeScale = 0.3f;
            this.anime.speed = 0.3f;
            Invoke("MosqSlowStop", 2.5f);
        }
        else Time.timeScale = 1f;

        if(!MosqMoveStop)
        {
        target = GameObject.Find("Player");
        
        if(target.transform.position.x > this.transform.position.x)
        {
             spriteRenderer.flipX = true;
        }
        if(target.transform.position.x < this.transform.position.x) //방향 전환
        {
            spriteRenderer.flipX = false;
        }

        direction = (target.transform.position - transform.position).normalized;
        accelaration = 0.008f;
        velocity = (velocity + accelaration * Time.deltaTime);

        float distance1 = Vector3.Distance(target.transform.position, transform.position); 
        
        if (distance1 < 20.0f) //두 물체간의 거리가 20보다 작으면 발견한 거임
        {
            this.transform.position = new Vector3(transform.position.x + 
            (direction.x * velocity), transform.position.y + (direction.y * velocity));
        }
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.tag.Equals("bullet"))  
        {
            anime.SetTrigger("Hits");
            //MosqHP.Mosq_HP -= 10f;
            MosqTempHP -= 10f;
            //if (MosqHP.Mosq_HP == 0) 
            if (MosqTempHP <= 0) 
            {
                DateManager.Instance.DiePoints += 0.1f; //킬 수 기록

                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity); 
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); 
                //모기 죽음
                Destroy(this.gameObject, 0.2f); 
                CountDie += 1;

                //y축 반전
                spriteRenderer.flipY = true;
                //낙하
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                coll.enabled = false;

                 int ran = Random.Range(0, 10);
                if(ran < 5)
                {
                    Debug.Log("아이템 드랍 안 됨");
                }
                else if(ran > 5)
                {
                    GameObject MosqCoin = Instantiate(MosqCoinPre, transform.position, Quaternion.identity);
                }
            }
        }

        if(other.gameObject.tag.Equals("Player"))
        {
            anime.SetBool("Attack", true);
            velocity = 0;
            accelaration = 0;
        }

         if (Player.Super_Shot == true)  
        {
            if (other.gameObject.tag.Equals("bullet"))  
        {
            MosqTempHP -= 50f;
            Destroy(this.gameObject);

            ParticleSystem instance = Instantiate(SuperShotDie, transform.position, Quaternion.identity); 
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration); 
            SoundManager.instance.SFXPlay("BossCritical", Die_clip);
        }
        }
    }
    public void MosqSlowStop()
    {
        Player.HighBlood_On = false;
    }
}
