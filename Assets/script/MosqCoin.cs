using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqCoin : MonoBehaviour
{
  public static int MosqCoins;

  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
            
            MosqCoins += 1;
        }
    }
}
