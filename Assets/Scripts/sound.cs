using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton; 
    public AudioClip clickSound; 
    private GameObject soundPlayer; 

    void Start()
    {

        if (yourButton != null)
        {
            yourButton.onClick.AddListener(PlayClickSound);
        }


        soundPlayer = new GameObject("SoundPlayer");
        soundPlayer.AddComponent<AudioSource>();
    }


    void PlayClickSound()
    {
        if (clickSound != null)
        {
          
            soundPlayer.GetComponent<AudioSource>().PlayOneShot(clickSound);
        }
    }

    private void OnDestroy()
    {
        Destroy(soundPlayer);
    }
}