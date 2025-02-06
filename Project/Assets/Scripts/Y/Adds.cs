using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Adds : MonoBehaviour
{
    private InterstitialAd interstitial_Ad;
    private string interstitial_Ad_ID;
    PlayerController Player;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            Invoke("ReferencePlayer", 0.01f);
    }
    private void ReferencePlayer() { if (SceneManager.GetActiveScene().buildIndex != 0)
            Player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    } 

    private void Start()
    {
        interstitial_Ad_ID = "ca-app-pub-7157078877191465/9883387041";
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
    }


    public void StartGame()
    {
        ShowInterstitial();
    }



    private void RequestInterstitial()
    {
        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);
        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;
        interstitial_Ad.OnAdClosed += HandleOnAdClosed;
        interstitial_Ad.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial_Ad.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial_Ad.IsLoaded())
        {
            interstitial_Ad.Show();
            RequestInterstitial();
        }

    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)

        Player.Win();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)

       Player.Win();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
    }

}