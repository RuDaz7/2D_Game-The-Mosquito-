using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionParticle; //사용할 파티클 변수 이름 지정, 퍼블릭으로 인스펙터창 표시직접 사입
    public Vector3 direction; //xyz를 가지고 있는 백터3를 direction이름으로 선언
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.unscaledDeltaTime; //총알의 위치는 = xyz공간에 * 속도 * 시간을 더한값 
        if(Player.HighBlood_On == true && Player.CoolMode_On == true)
        {
            speed += 10;
        }
    }
    void OnBecameInvisible() //카메라 시야 밖으로 벗어나면> 조건 함수
    {
        Destroy(gameObject); //파괴
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration);

        if (other.gameObject.tag.Equals("enemy"))
        {
            Destroy(this.gameObject);
        }
    }

}