using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public ParticleSystem Die_Particle; //보스 사망 임팩트

    Animator anime;
    SpriteRenderer spriteRenderer;
    public AudioClip Die;
    public AudioClip Hit;
    public AudioClip Attack;
    public AudioClip Cri;
    public ParticleSystem SuperShot;
    public Transform Target;

    public GameObject prfHpBar;//
    public GameObject canvas;//
    RectTransform hpBar;//
    public float height = 2.0f;//
    public bool BossMove;
    public bool TagetOn;

    void Start()
    {
        anime = GetComponent<Animator>(); //애니메이션 사용을 위해 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>(); //반향 전향을 위해 가져옴
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();//
        BossMove = true;
    }
    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;//

        if (BossMove) //목적지로 계속 이동함
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
            transform.Translate(Vector3.right * 0.0f);

        //방향 전환
        if (Target.transform.position.x > this.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        if (Target.transform.position.x < this.transform.position.x) //방향 전환
        {
            spriteRenderer.flipX = false;
        }
        //플레이어와 거리 계산
        float AttackDistance = Vector3.Distance(Target.transform.position, transform.position);
        Debug.Log("현재 거리 " + AttackDistance);

        //거리가 10다 가까우면 
        if (AttackDistance < 15 && AttackDistance > 10)
        {
            anime.SetBool("WindAT", true);
            transform.position += new Vector3(0, 3f * Time.deltaTime, 0);
            BossMove = false;
            Invoke("BossAT", 1f);
            TagetOn = true;
        }
        else
        {
            anime.SetBool("WindAT", false);
            anime.SetBool("Idle", true);
            BossMove = true;
            TagetOn = false;
        }
        if (AttackDistance < 5 && AttackDistance > 2)
        {
            anime.SetBool("BiteAT", true);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, 5 * Time.deltaTime);
            BossMove = false;
            //TagetOn = true;
        }
        else
        {
            anime.SetBool("BiteAT", false);
            anime.SetBool("Idle", true);
            BossMove = true;
            TagetOn = false;
        }

        if (TagetOn)
        {
            SoundManager.instance.SFXPlay("Attack", Attack);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("bullet"))
        {
            BossHP.Boss_HP -= 10f;
            SoundManager.instance.SFXPlay("Hit", Hit);

            if (BossHP.Boss_HP <= 0)
            {
                SoundManager.instance.SFXPlay("Die", Die);
                anime.SetBool("Die", true);
                BossMove = false;
                ParticleSystem instance = Instantiate(Die_Particle, transform.position, Quaternion.identity);
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration);

                //낙하
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                coll.enabled = false;
            }
        }
        if (Player.Super_Shot == true)
        {
            if (other.gameObject.tag.Equals("bullet"))
            {
                SoundManager.instance.SFXPlay("Cri", Cri);
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
    public void BossAT()
    {
        transform.position += new Vector3(0, -3f * Time.deltaTime, 0);
    }
}

