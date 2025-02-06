using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    [HideInInspector] public int _coins = 0;
    private int Coins = 0;
    [HideInInspector] public int RealCoins;
    [HideInInspector] public int _score;
    private int Score = 0;
    Text CoinsText;
    Transform shop;
    [SerializeField] GameObject Note;
    GameObject NoteObject;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            shop = GameObject.Find("Canvas").transform.Find("Shop").transform.Find("Point").transform;
            CoinsText = GetComponent<Text>();
            InvokeRepeating(nameof(Caluclate), 0f, 1f);
        }
           
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadData();



    }
    private void Update()
    {
       
        //if (Input.GetKeyDown(KeyCode.Q))
        //    AddCoins(1000);
        if (_coins != Coins)
        {
            Coins = _coins;
            if (SceneManager.GetActiveScene().buildIndex == 0)
                LoadData();

        }
        if (_score != Score)       
            Score = _score;
  
    }
    public void LoadData()
    {
        CoinsText.text = _coins.ToString();
    }
    public void AddCoins(int coinsAmount)
    {
       
        _coins += coinsAmount;
        if (SaveData.instance != null)
            SaveData.instance.Save();
    }
    public void AddScore(int scoreamount)
    {

        _score += scoreamount;
        if (SaveData.instance != null)
            SaveData.instance.Save();
    }
    public void MinusCoins(int coinsAmount)
    {
        if (_coins >= coinsAmount)
        {
           
            _coins -= coinsAmount;
            if (SaveData.instance != null)
                SaveData.instance.Save();
        }

        else
        {
            
            NoteObject = Instantiate(Note, shop.transform.position, Quaternion.identity, shop);
            Destroy(NoteObject, 2f);
        }
         
        
        
    }

   
    public void Caluclate() => RealCoins = _coins;
}
