using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  public static  SoundManager instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] AudioSource MainSource;
    [SerializeField] AudioSource SecoundSource;

    [SerializeField] AudioClip[] Audios;
    [SerializeField] GameObject[] AudiosGameObjects;
    GameObject HammerSoundPrefab;
    GameObject AbilitySoundPrefab;
    GameObject HitvirusSoundPrefab;
    GameObject ChestSoundPrefab;
    enum Audio { MainSoundIndustrial,hammer,ablility,hitvirus,jumpsound,playerdamage,ShootV,Dead,Chest,Treasure }
    
       
    
   
    public void HammerSound() {

        if (HammerSoundPrefab == null)
        {
            HammerSoundPrefab = Instantiate(AudiosGameObjects[0], transform.position,
       Quaternion.identity, null); Destroy(HammerSoundPrefab, 1f);
        }
        } 
    public void ablilitySound()
    {
        if (AbilitySoundPrefab == null)
        {
            AbilitySoundPrefab = Instantiate(AudiosGameObjects[1], transform.position,
       Quaternion.identity, null); Destroy(AbilitySoundPrefab, 1f);
        }
    } 
    public void hitvirusSound() {
        if (HitvirusSoundPrefab == null)
        {
            HitvirusSoundPrefab = Instantiate(AudiosGameObjects[2], transform.position,
       Quaternion.identity, null); Destroy(HitvirusSoundPrefab, 1f);
        }
    } 
    public void jumpsound() { if (!SecoundSource.isPlaying) SecoundSource.PlayOneShot(Audios[4], 1f);}
    public void playerdamageSound() {  SecoundSource.PlayOneShot(Audios[5], 1f);}
    public void ShootVSound() { if (!SecoundSource.isPlaying) SecoundSource.PlayOneShot(Audios[6], 1f);}
    public void DeadVSound() { if (!SecoundSource.isPlaying) SecoundSource.PlayOneShot(Audios[7], 1f);}
    public void ChestVSound() {  if (ChestSoundPrefab == null)
        {
            ChestSoundPrefab = Instantiate(AudiosGameObjects[3], transform.position,
       Quaternion.identity, null); Destroy(ChestSoundPrefab, 1f);
        } }
    public void TreasureVSound() {  SecoundSource.PlayOneShot(Audios[9], 1f); }
    public void WhooshVSound() { SecoundSource.PlayOneShot(Audios[10], 1f); }

}
