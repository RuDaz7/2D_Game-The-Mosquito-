using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    public ParticleSystem explosionParticle;
    bool HP = false;
    public float count;
    public Transform aim;
    public GameObject bulletPrefab; //가지고올 프리팹
    private Camera cam; //가지고올 카메라를 cam에 저장
    SpriteRenderer spriteRenderer;
    Animator anime;
    Rigidbody2D rigid;
    public ParticleSystem particleObject; //파티클시스템
    public AudioClip clip;

    void Start()
    {
        cam = Camera.main; //cam에 메인카메라를 대입
        spriteRenderer = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        particleObject.Stop();
    }

    // Update is called once per frame    
    int speed = 10;
    int JumpPower = 10;
    public bool isJumping;
    public bool SpeedRun;
    void Update()
    {
        if(DateManager.Instance.DiePoints >= 50)
        {
            SpeedRun = true;
        }
        else SpeedRun = false;

         if(Input.GetKeyDown(KeyCode.Q) && SpeedRun == true)
            {
            speed += 3;
            particleObject.Play();
            }

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
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
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
            GetComponent<AudioSource>().Play();
            //SoundManager.instance.SFXPlay("Shoot", clip);
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
        if (count == 3)
        {
            HP = true;
        }

        if (other.gameObject.tag.Equals("enemy"))
        {
            count += 1;

            if (HP == true)
            {
                ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration);
                Destroy(this.gameObject);
            }
        }

    }
}
