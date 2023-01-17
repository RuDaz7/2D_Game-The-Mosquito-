using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    public ParticleSystem explosionParticle;
    public Transform aim;
    public GameObject bulletPrefab; //가지고올 프리팹
    private Camera cam; //가지고올 카메라를 cam에 저장
    SpriteRenderer spriteRenderer;
    Animator anime;
    Rigidbody2D rigid;
    public ParticleSystem particleObject; //파티클시스템
    public AudioClip Shoot; 
    public AudioClip Hap;
    public AudioClip Blood_Boom;
    public AudioClip SpeedRun_Sound;
    public AudioClip SpeedRun_On_Sound;
    public static bool CoolMode_On = false;
    public static bool HighBlood;
    public ParticleSystem HighBl_Fire;
    public ParticleSystem HighBl_Boom;
    public bool MoveStop = false;

    void Start()
    {
        cam = Camera.main; //cam에 메인카메라를 대입
        spriteRenderer = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        particleObject.Stop();
    }

    // Update is called once per frame    
    public static int speed = 10;
    int JumpPower = 10;
    public bool isJumping;
    void Update()
    {
        //고혈압모드
        if(Input.GetKeyDown(KeyCode.E))
        {
             SoundManager.instance.SFXPlay("HighBlood_Sound", Hap);
             Invoke("BloodBoom_Sound",0.9f);

            ParticleSystem instance = Instantiate(HighBl_Fire, transform.position, Quaternion.identity);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration);
            spriteRenderer.material.color = Color.red;   
            MoveStop = true;
            Invoke("MoveOn", 1f);
        }

        //쿨모드
        if(Cool_Gauge.CoolMode == true)
        {
         if(Input.GetKeyDown(KeyCode.Q))
            {
            CoolAttack_Start();
            particleObject.Play();
            SoundManager.instance.SFXPlay("CoolSound", SpeedRun_Sound);
            spriteRenderer.material.color = Color.cyan;
            SoundManager.instance.SFXPlay("CoolSound", SpeedRun_On_Sound);
            }
        }
        if(DateManager.CoolTime <= 0)
        {
            CoolMode_On = false;
            CoolAttack_Stop();
            particleObject.Stop();
        }
        if(MoveStop == false)
        {
        //점프
        if(isJumping == true)
        {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            isJumping = false;
            anime.SetBool("Jump_On", true);
        }
        }
   
        //이동
        float xMove = Input.GetAxis("Horizontal") * speed * Time.unscaledDeltaTime; //x축으로 이동할 양
          this.transform.Translate(new Vector3(xMove, 0, 0));  //이동

        //워킹 애니메이션 조건
        if(Input.GetAxis("Horizontal") == 0)
            anime.SetBool("Walk_On", false);
        else
            anime.SetBool("Walk_On", true);

        //에임
        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition); //xyz값을 담을 수 있는 wordPos에 메인카메라의 월드좌표와 마우스 위치 
        worldPos.z = 0;
        aim.position = worldPos;
        //에임을 통한 방향 전환
        if(worldPos.x < this.transform.localPosition.x)
        {
            spriteRenderer.flipX = true;
        }
         if(worldPos.x > this.transform.localPosition.x)
        {
            spriteRenderer.flipX = false;
        }

        //공격
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (aim.position - transform.position).normalized;
            //Bullet 클래스 bullet을 선언
            Bullet bullet = bulletObj.GetComponent<Bullet>();

            bullet.direction = direction;
            bullet.speed = 20;
            //GetComponent<AudioSource>().Play();
            SoundManager.instance.SFXPlay("Shoot", Shoot);
        }
    }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
           if (other.gameObject.name.Equals("GROUND"))
        {
            isJumping = true;
             anime.SetBool("Jump_On", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy"))
        {
            PlayerHP.Player_HP -= 10f;

            if (PlayerHP.Player_HP == 0)
            {
                ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration);
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag.Equals("Deadline"))
        {
            gameObject.transform.position = new Vector3(-80, 1.7f, 0);
        }
    }
    public static void CoolAttack_Start()
    {
            speed += 3;
            CoolMode_On = true;
    }
     public static void CoolAttack_Stop()
    {   
        speed -= 3;
        DateManager.Instance.DiePoints = 0;
        DateManager.CoolTime = 10;
    }
    public void BloodBoom_Sound()
    {
        SoundManager.instance.SFXPlay("HighBloodSound_Boom", Blood_Boom);

         ParticleSystem instance = Instantiate(HighBl_Boom, transform.position, Quaternion.identity);
         instance.Play();
         Destroy(instance.gameObject, instance.main.duration);
         HighBlood = true;
    }
    public void MoveOn()
    {
        MoveStop = false;
    }
}
