using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
public ParticleSystem Die_Particle; //보스 사망 임팩트

Animator anime;
SpriteRenderer spriteRenderer;
public AudioClip DieSound; 
public ParticleSystem SuperShot;
GameObject target;

public GameObject prfHpBar;//
public GameObject canvas;//
RectTransform hpBar;//
public float height = 2.0f;//
public bool BossMove;
public float AttackTime;

    void Start()
    {   
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴
        GetComponent<AudioSource>().Play();
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();//
        BossMove = true;
    }
    void Update()
    {
        AttackTime += Time.unscaledDeltaTime;
        target = GameObject.Find("Player");

        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;//

        if(BossMove)
        {
        transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        transform.Translate(Vector3.right * 0.0f);
        
        if(target.transform.position.x > this.transform.position.x)
        {
             spriteRenderer.flipX = true;
        }
        if(target.transform.position.x < this.transform.position.x) //방향 전환
        {
            spriteRenderer.flipX = false;
        }

         float AttackDistance1 = Vector3.Distance(target.transform.position, transform.position); 
         float AttackDistance2 = Vector3.Distance(target.transform.position, transform.position); 
        if(AttackTime < 10)
        {
         if (AttackDistance1 < 10.0f)
        {
         anime.SetBool("WindAT", true);
        }
        if(AttackDistance1 > 10.0f )
        {
         anime.SetBool("WindAT", false);
        }
        }

        Debug.Log("현재 거리"+AttackDistance1);

        if(AttackTime > 10)
        {
          if(AttackDistance2 < 5.0f)
        {
            anime.SetBool("BiteAT", true);
        }
             if(AttackDistance2 > 5.0f)  
        {
            anime.SetBool("BiteAT", false);
        }

        if(AttackTime >= 20)
        {
            AttackTime = 0;
        }
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.tag.Equals("bullet"))  
        {
            BossHP.Boss_HP -= 10f;

            if (BossHP.Boss_HP <= 0) 
            {
                anime.SetBool("Die", true);
                BossMove = false;
                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity); 
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); 

                //낙하
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                coll.enabled = false;
                SoundManager.instance.SFXPlay("BossCritical", DieSound);
            }
        }
         if (Player.Super_Shot == true)  
        {
            if (other.gameObject.tag.Equals("bullet"))  
        {
            BossHP.Boss_HP -= 70f;
            anime.SetTrigger("Cri");
            ParticleSystem instance = Instantiate(SuperShot, transform.position, Quaternion.identity); 
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration); 
        }
        }
    }
     void OnTriggerExit2D(Collider2D other) 
    {
        anime.SetBool("Idle", true);
    }
}

