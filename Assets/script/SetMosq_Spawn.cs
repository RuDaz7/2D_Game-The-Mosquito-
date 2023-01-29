using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMosq_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.MaxTime > 20.0f)
        {
            gameObject.SetActive(true);
        }
        else
        gameObject.SetActive(false);
    }
}
