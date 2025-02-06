using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Tween : MonoBehaviour
{
    [SerializeField] RectTransform main, howToPlay, shop, settings, play, win, die, chest;
    [SerializeField] float tweenSpeed;
    [SerializeField] float tweenSpeed2;
    Vector2 vmain, vhowToPlay, vShop, vSettings, vPlay, vWin, vDie, vChest;
    Vector2 Advancedshop = new Vector2(0, -50);
    Vector2 Advancedhow = new Vector2(0, 50);
   
    [SerializeField] Animator _chestAnimator;
    private void Awake()
    {
        vPlay = play.transform.localPosition;
        if (main)
        {
            vmain = main.transform.localPosition;
            vhowToPlay = howToPlay.transform.localPosition;
            vShop = shop.transform.localPosition;
            vSettings = settings.transform.localPosition;

        }
        else
        {
            vChest = chest.transform.localPosition;
            vWin = win.transform.localPosition;
            vDie = die.transform.localPosition;
        }

    }
  
    private void Start()=>main.DOAnchorPos(Vector2.zero, tweenSpeed);
    public void MainM(bool Turn)
    {
        if (Turn)
            main.DOAnchorPos(Vector2.zero, tweenSpeed);
        else
            main.DOAnchorPos(vmain, tweenSpeed);
    }
    public void HowToPlay(bool Turn)
    {
        if (Turn)
            howToPlay.DOAnchorPos(Advancedhow, tweenSpeed);
        else
            howToPlay.DOAnchorPos(vhowToPlay, tweenSpeed);
    }
    public void Shop(bool Turn)
    {
        if (Turn)
            shop.DOAnchorPos(Advancedshop, tweenSpeed);
        else
            shop.DOAnchorPos(vShop, tweenSpeed);
    }

    public void Settings(bool Turn)
    {
        if (Turn)
            settings.DOAnchorPos(Vector2.zero, tweenSpeed);
        else
            settings.DOAnchorPos(vSettings, tweenSpeed);
    }
    public void Play(bool Turn)
    {
        if (Turn)
            play.DOAnchorPos(Vector2.zero, tweenSpeed2);
        else
            play.DOAnchorPos(vPlay, tweenSpeed2);
    }
    public void Win(bool Turn)
    {
        if (Turn)
            win.DOAnchorPos(Advancedhow, tweenSpeed2);
        else
            win.DOAnchorPos(vWin, tweenSpeed2);
    }
    public void Die(bool Turn)
    {
        if (Turn)
            die.DOAnchorPos(Vector2.zero, tweenSpeed2);
        else
            die.DOAnchorPos(vDie, tweenSpeed2);
    }
    public void Chest(bool Turn)
    {
        if (Turn)
        {
            _chestAnimator.enabled = true;
            chest.DOAnchorPos(Vector2.zero, tweenSpeed2);
        }
        else
        {
            _chestAnimator.enabled = false;
            chest.DOAnchorPos(vChest, tweenSpeed2);
        }
    }
}

