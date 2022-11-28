using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosq : MonoBehaviour
{
    public ParticleSystem explosionParticle; //���� ��ƼŬ
    public GameObject enemy;//�� ������Ʈ
    bool HP = false; //���� ����
    public float count; //���� �Ѿ� ī��Ʈ
    Vector3 position;
    public float WalkTime; //���Ͱ� �¿�� �̵��ϴ� �ð�
    public bool Stop; //���� ���� ����
    public bool Target; //���� ����
    public Transform target; //Ÿ�� ��ġ
    public float StopTime;//���Ͱ� �����ϴ� �ð�
    public float enemyMoveSpeed; //�� �̵� �ӵ�
    public Vector3 direction;
    public float velocity;
    public float accelaration;

    //public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemyMoveSpeed = 2.0f;
        position = transform.position;
        count = 1; //�ʱ� ī��Ʈ ����;
        Stop = false; //��ž �ʱⰪ
        Target = false; //Ÿ�� �ʱ� ����
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        // ���ӵ� ���� (���� ���� ����, �Ÿ� �� ����ؼ� ������ ��)
        accelaration = 0.008f;
        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = (velocity + accelaration * Time.deltaTime);

        //GameObject enemyObj = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        //Enemy enemy = enemyObj.GetComponent<Enemy>();

        WalkTime += Time.deltaTime; //��ũ Ÿ�ӿ� �ð��� ��� ������
        StopTime += Time.deltaTime; //��ž Ÿ�ӿ� �ð��� ��� ������
        //
        float distance1 = Vector3.Distance(target.position, transform.position); //�Ÿ����ϱ�

        if (Target == false) //Ÿ���� ���� �����ȿ� ���ٸ�
        {
            if (Stop == false) // ��ž�� �޽� �϶� ���ʹ� ������
            {
                if (WalkTime > 5) //5�� ���� �ڷ� �̵�
                {
                    position.x += 2 * Time.deltaTime;
                    transform.position = position;
                }
                if (WalkTime < 5) //5�� ���� ������ �̵�
                {
                    position.x += -2 * Time.deltaTime;
                    transform.position = position;
                }
                if (WalkTime > 10) //10�� ���������
                {
                    WalkTime = 0; //0���� �ʱ�ȭ
                }
            }
            if (StopTime > 20) //��žŸ���� 20�ʰ� �Ǹ�
            {
                Stop = true; //��ž�� Ʈ�簡 �ȴ�
            }
            if (Stop == true) //��ž�� Ʈ���̸� ������ ����
            {
                position.x += 0 * Time.deltaTime;
                transform.position = position;
            }
            if (StopTime > 25) //��žŸ���� 25�ʰ� �Ǹ�
            {
                Stop = false; //��ž�� �޽��� ���ϰ�
                StopTime = 0; //��žŸ���� 0���� �ʱ�ȭ
                WalkTime = 0; //0���� �ʱ�ȭ
            }

        }

        if (distance1 <= 12.0f) //Ÿ�ٰ��� �Ÿ��� 1���� ũ�ų� ������ 
        {
            Target = true; //Ÿ���� Ʈ��
            Stop = false; //�÷��̾ �����Ҷ� ���߸� �ȵǱ� ������ ��ž�� �޽�
        }
        if (Target == true) //��ž�� Ʈ���϶�
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity));

        }
        if (distance1 > 40.0f) //Ÿ�ٰ��� �Ÿ��� 15���� ũ�� 
        {
            Target = false; //Ÿ���� �޽�
        }
    }

    void OnTriggerEnter2D(Collider2D other) //�浹 Ȯ��
    {
        if (count == 5) //ī���Ͱ� 5���
        {
            HP = true; //���� �Ҹ�
        }

        if (other.gameObject.tag.Equals("bullet"))  //�ε��� ��ü�� �±׸� ���ؼ� ������ �Ǵ�

        {
            count += 1; //�Ѿ˿� �ε����� ���� ī���� 1�� ����

            if (HP == true) //HP�� Ʈ���� ��
            {
                ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity); //��ƼŬ �߻�
                instance.Play();
                Destroy(instance.gameObject, instance.main.duration); //��ƼŬ ����
                Destroy(this.gameObject); //���� ����
            }
        }
    }
}
