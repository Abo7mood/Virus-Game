using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnimationEvent : MonoBehaviour
{
    public SoundManager SoundManager;
     PlayerController player;
   public Animator chest;
    public TextMeshProUGUI CoinsText;
    public Tween _tween;
    PlayerInfo _playerInfo;
    private void Awake()
    {
        SoundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
        Invoke("ReferencePlayer", 0.01f);
        _playerInfo = FindObjectOfType<PlayerInfo>().GetComponent<PlayerInfo>();
    }
    public void MinusSoul() => player.playerhealthdisable();
    public void LiveActive() => player.Live();
    public void resetanimation() { gameObject.GetComponent<Animator>().SetTrigger("1"); }
    public void EnableCollider() { SoundManager.HammerSound(); gameObject.GetComponent<BoxCollider2D>().enabled = true; } 
    public void DisableCollider() => gameObject.GetComponent<BoxCollider2D>().enabled = false;
    private void ReferencePlayer() => player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    private void ChestSound() => SoundManager.ChestVSound();
    private void TreasureSound() => SoundManager.TreasureVSound();

    public void ChestEnable()
    {
       this.gameObject.GetComponent<Button>().interactable = false;
        chest.SetTrigger("Intract");
        CoinsText.text = LevelManager.instance.CoinsAmount.ToString();
        StartCoroutine(ChestC(5));
        _playerInfo.AddCoins(1);
    }
    IEnumerator ChestC(int time)
    {

        yield return new WaitForSeconds(time);
        _tween.Chest(false);
        _tween.Win(true);
        SoundManager.instance.WhooshVSound();
    }
}
