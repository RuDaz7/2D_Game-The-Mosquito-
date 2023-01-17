using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosq : MonoBehaviour
{
    public static bool Boss_HP_Zero = false;
    public ParticleSystem Die_Particle; //모기 사망 임팩트
    bool HP = false; //사망 초기값은 펄스
    public float count; //맞은 횟수
    Vector3 position;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    Animator anime;
    SpriteRenderer spriteRenderer;
    GameObject target;
    public AudioClip Die_clip; 
    public float Sc_Timer;
    void Start()
    {   
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴
        position = transform.position;
        count = 1; 
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        Sc_Timer += Time.deltaTime;
        if(Player.HighBlood == true)
        {
            Time.timeScale = 0.6f;
        }
        else Time.timeScale = 1f;

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
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (count == 5) 
        {
            HP = true; 
        }

        if (other.gameObject.tag.Equals("bullet"))  
        {
            anime.SetTrigger("Hits");
            count += 1;
            if (HP == true) 
            {
                DateManager.Instance.DiePoints += 0.1f; //킬 수 기록
                
                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity); 
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); 
                Destroy(this.gameObject, 0.3f); 

                //y축 반전
                spriteRenderer.flipY = true;
                //낙하
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                coll.enabled = false;
            }
            //SoundManager.instance.SFXPlay("BossCritical", Die_clip);
        }

        if(other.gameObject.tag.Equals("Player"))
        {
            anime.SetBool("Attack", true);
            velocity = 0;
            accelaration = 0;
        }
         if (other.gameObject.tag.Equals("SuperBullet"))  
        {
            Destroy(this.gameObject, 0.3f); 
            Debug.Log("시원하다!");
        }
    }
}
