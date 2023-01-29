using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public ParticleSystem Die_Particle; //보스 사망 임팩트

    Animator anime;
    SpriteRenderer spriteRenderer;
    public AudioClip Die_clip; 
    public ParticleSystem SuperShotDie;
     GameObject target;

     public bool Boss_On = true;

// public GameObject prfHpBar;
// public GameObject canvas;
// RectTransform hpBar;
// public float height = 1.7f;

    void Start()
    {   
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴
        GetComponent<AudioSource>().Play();

        // hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
    }
    void Update()
    {
        if(Boss_On)
        {
        transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);

         target = GameObject.Find("Player");
        
        if(target.transform.position.x > this.transform.position.x)
        {
             spriteRenderer.flipX = true;
        }
        if(target.transform.position.x < this.transform.position.x) //방향 전환
        {
            spriteRenderer.flipX = false;
        }

        float distance1 = Vector3.Distance(target.transform.position, transform.position); 

         if (distance1 < 3.0f)
        {
            anime.SetBool("WindAT", true);
        }
        else
        anime.SetBool("WindAT", false);
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

                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity); 
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); 
 
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);

                //낙하
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                coll.enabled = false;
            }
        }

        if(other.gameObject.tag.Equals("Player"))
        {
            anime.SetTrigger("BiteAT");
        }

         if (Player.Super_Shot == true)  
        {
            if (other.gameObject.tag.Equals("bullet"))  
        {
            BossHP.Boss_HP -= 70f;

            anime.SetTrigger("Cri");
            ParticleSystem instance = Instantiate(SuperShotDie, transform.position, Quaternion.identity); 
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration); 
            SoundManager.instance.SFXPlay("BossCritical", Die_clip);
        }
        }
    }
}

