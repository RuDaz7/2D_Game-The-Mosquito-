using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public GameObject enemy;
    bool HP = false;
    public float count;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        count = 1;
    }


    // Update is called once per frame
    void Update()
    {
        position.x += -1 * Time.deltaTime;
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (count == 15)
        {
            HP = true;
        }
        if (count == 9)
        {
            ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            instance.Play();
        }
        if (count == 13)
        {
            ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            instance.Play();
        }


        if (other.gameObject.tag.Equals("bullet"))
        //�ε��� ��ü�� �±׸� ���ؼ� ������ �Ǵ��մϴ�.
        {
            count += 1;

            if (HP == true)
            {
                ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration);
                Destroy(this.gameObject);
                //�ڽ��� �ı��մϴ�.
            }
        }

    }
}