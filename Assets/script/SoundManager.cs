using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager instance;
  private void Awake() 
    {
        if(instance == null)
        {
            instance = this; //자신을 넣어줘라
            DontDestroyOnLoad(instance); //씬 전환되도 파괴안됨
        } 
        else
        {
            Destroy(gameObject);
        }
    }
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }
}
