using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //

public class PlayerHP : MonoBehaviour
{
    Image PlayerBackHP;//
    float MaxHP = 5000f;//
    public static float Player_HP;//
    // Start is called before the first frame update
    void Start()
    {
        PlayerBackHP = GetComponent<Image>();//
        Player_HP = MaxHP;//
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBackHP.fillAmount = Player_HP / MaxHP;
    }
}
