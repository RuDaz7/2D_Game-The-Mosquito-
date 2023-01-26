using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqCoin : MonoBehaviour
{
  public static float MosqCoins;

  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
            MosqCoins += 1.0f;
        }
    }

      void OnBecameInvisible() //카메라 시야 밖으로 벗어나면> 조건 함수
    {
        Destroy(gameObject); //파괴
    }
}
