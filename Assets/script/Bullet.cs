using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public Vector3 direction;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration);

        if (other.gameObject.tag.Equals("enemy"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            Destroy(this.gameObject);
            //자신을 파괴합니다.
        }
    }

}