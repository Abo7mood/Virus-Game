using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundScripts : MonoBehaviour
{
  
    public AudioMixer soundmixer;
    public AudioMixer musicmixer;
   
    [SerializeField] Image musicIcon,soundIcon,handleMusicIcon, handleSoundIcon;[Space(10)]


    [SerializeField] Sprite[] audioIcons;
    private void Start()
    {

    }
    public void SetSound(float Sound)
    {
        soundmixer.SetFloat("Sound", Sound);
        PlayerPrefs.SetFloat("Sound", Sound);
        PlayerPrefs.GetFloat("Sound", Sound);
        if (Sound <= 0)
        {
            soundIcon.sprite = audioIcons[3];
            handleSoundIcon.sprite = audioIcons[1];
        }
        else
        {
            soundIcon.sprite = audioIcons[2];
            handleSoundIcon.sprite = audioIcons[0];
        }
    }
    public void SetMusic(float Music)
    {
        musicmixer.SetFloat("Music", Music);
        PlayerPrefs.SetFloat("Music", Music);
        PlayerPrefs.GetFloat("Music", Music);
        if (Music <= 0)
        {
            musicIcon.sprite = audioIcons[5];
            handleMusicIcon.sprite = audioIcons[1];
        }
        else
        {
            musicIcon.sprite = audioIcons[4];
            handleMusicIcon.sprite = audioIcons[0];
        }
            

    }



}
