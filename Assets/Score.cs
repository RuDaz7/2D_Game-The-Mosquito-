using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Score : MonoBehaviour
{

    static int score = 0;

    public static void setScore(int value)
    {
        score += value;
    }

    public static int getScore()
    {
        return score;
    }
	//화면에 점수를 띄워준다
    void OnGUI()
    {
        GUILayout.Label("Score : " + score.ToString());
    }
}
