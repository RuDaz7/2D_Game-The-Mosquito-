using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  public float spwanTime = 2.0f;
  public float curTime;
  public Transform[] spawnPoints;
  public GameObject mosqPrefab;

   private void Update()
    {
        if(curTime >= spwanTime)
        {
            int x = Random.Range(0, spawnPoints.Length);
            SpawnMosq(x);
        }
        curTime += Time.deltaTime;
    }
    public void SpawnMosq(int ranNum)
    {
        curTime = 0;
        Instantiate(mosqPrefab, spawnPoints[ranNum]);
    }
}
