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

    void Start()
    {
        cam = Camera.main; //cam에 메인카메라를 대입
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame    
    int speed = 10;

    float xMove, yMove;

    void Update()

    {
        //방향 전환
        spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        //이동
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동

        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition); //xyz값을 담을 수 있는 wordPos에 메인카메라의 월드좌표와 마우스 위치 
        worldPos.z = 0;

        aim.position = worldPos;

        if (Input.GetMouseButtonDown(0))
        {

            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (aim.position - transform.position).normalized;
            //Bullet 클래스 bullet을 선언
            Bullet bullet = bulletObj.GetComponent<Bullet>();

            bullet.direction = direction;
            bullet.speed = 20;
            GetComponent<AudioSource>().Play();
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
