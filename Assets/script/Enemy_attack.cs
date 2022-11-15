using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
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

        if (other.gameObject.tag.Equals("Player"))
        //�ε��� ��ü�� �±׸� ���ؼ� ������ �Ǵ��մϴ�.
        {
            Destroy(this.gameObject);
            //�ڽ��� �ı��մϴ�.]
        }
    }

}