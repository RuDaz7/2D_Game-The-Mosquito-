using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public static float cameraSpeed = 5.0f;

    public GameObject player; //이런 이름을 찾는다는게 아니고 필드변수임 Player에 누굴 넣을건지 퍼블릭으로 칸을 생성해주는거임 첫자 대문자는 무시
//gameObject <= 얘가 접근임 찾는거
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}