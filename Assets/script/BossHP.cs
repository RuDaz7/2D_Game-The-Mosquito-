using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    Image BossBackHP;//
    float BossMaxHP = 500f;//
    public static float Boss_HP;//
    
    void Start()
    {
        BossBackHP = GetComponent<Image>();//
        Boss_HP = BossMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        BossBackHP.fillAmount = Boss_HP / BossMaxHP;
    }
}
