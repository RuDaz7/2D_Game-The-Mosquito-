using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public GameObject enemy;
    bool HP = false;
    public float count;
    public GameObject door;
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
        if (count == 50)
        {
            HP = true;
        }
        if (count == 30)
        {
            ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            instance.Play();
        }
        if (count == 15)
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
                count = 100;
            }
            if (count == 100)
            {
                Instantiate(door, transform.position, Quaternion.identity);
                count = 0;
            }
        }

    }
}