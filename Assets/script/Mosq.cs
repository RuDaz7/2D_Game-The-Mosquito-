using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosq : MonoBehaviour
{
    public ParticleSystem Die_Particle; //모기 사망 임팩트
    public GameObject enemy;//자기 자신
    bool HP = false; //사망 초기값은 펄스
    public float count; //맞은 횟수
    Vector3 position;
    public float WalkTime; //이동 시간
    public bool Stop; //정지 시간
    public bool Target; //탐색
    public Transform target; //목표
    public float StopTime;//멈추는 시간
    public float enemyMoveSpeed; //속도
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    Animator anime;
    SpriteRenderer spriteRenderer;

    //public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴

        enemyMoveSpeed = 2.0f;
        position = transform.position;
        count = 1; 
        Stop = false; 
        Target = false;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > this.transform.localPosition.x) //방향 전환
        {
            spriteRenderer.flipX = true;
        }
         if(target.position.x < this.transform.localPosition.x) //방향 전환
        {
            spriteRenderer.flipX = false;
        }

        direction = (target.position - transform.position).normalized;
        accelaration = 0.008f;
        velocity = (velocity + accelaration * Time.deltaTime);

        WalkTime += Time.deltaTime; 
        StopTime += Time.deltaTime;
    
        float distance1 = Vector3.Distance(target.position, transform.position); 

        if (Target == false) 
        {
            if (Stop == false)
            {
                if (WalkTime > 5) 
                {
                    position.x += 2 * Time.deltaTime;
                    transform.position = position;
                }
                if (WalkTime < 5)
                {
                    position.x += -2 * Time.deltaTime;
                    transform.position = position;
                }
                if (WalkTime > 10)
                {
                    WalkTime = 0;
                }
            }
            if (StopTime > 20)
            {
                Stop = true; 
            }
            if (Stop == true) 
            {
                position.x += 0 * Time.deltaTime;
                transform.position = position;
            }
            if (StopTime > 25) 
            {
                Stop = false; 
                StopTime = 0; 
                WalkTime = 0; 
            }
        }
        if (distance1 < 20.0f) //두 물체간의 거리가 20보다 작으면 발견한 거임
        {
            Target = true; 
            Stop = false; 
        }

        if (Target == true) 
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity));

        }
        if (distance1 > 40.0f) //두 물체간의 거리가 40보다 커지면 탐색 중지
        {
            Target = false; 
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (count == 5) 
        {
            HP = true; 
        }

        if (other.gameObject.tag.Equals("bullet"))  
        {
            count += 1; 
            anime.SetBool("Hits", true);

            if (HP == true) 
            {
                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity); 
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); 
                Destroy(this.gameObject); 
            }
        }
        // if(other.gameObject.tag.Equals("Player"))
        // {
        //     anime.SetBool("Attack", true);
        //     velocity = 0;
        // }
    }
}
