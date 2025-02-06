using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    [SerializeField] Image[] StageImage;
    [SerializeField] Sprite Normal,Completed,Locked;
    [SerializeField] Text[] LevelText;
   [HideInInspector] public int StageProgress;
    private int StageNumber;
    public void Start()
    {

        StageProgress = PlayerPrefs.GetInt("Progress", StageProgress);
        Debug.Log(StageProgress + "+" + "StageProgress1");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
      
        if (sceneName == "MainMenu")
        {
            Debug.Log(StageProgress + "+" + "StageProgress3");

           
            switch (StageProgress)
            {
                case 0:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Normal;
                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                    }
                   
                    break;
                case 1:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Completed;
                        StageImage[1].sprite = Normal;
                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        LevelText[1].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[1].gameObject.GetComponent<Button>().enabled = true;
                    }
                  
                    break;
                case 2:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Completed;
                        StageImage[1].sprite = Completed;
                        StageImage[2].sprite = Normal;
                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        LevelText[1].enabled = true;
                        LevelText[2].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[1].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[2].gameObject.GetComponent<Button>().enabled = true;
                        
                    }

                    break;
                case 3:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Completed;
                        StageImage[1].sprite = Completed;
                        StageImage[2].sprite = Completed;
                        StageImage[3].sprite = Normal;
                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        LevelText[1].enabled = true;
                        LevelText[2].enabled = true;
                        LevelText[3].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[1].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[2].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[3].gameObject.GetComponent<Button>().enabled = true;
                    }

                    break;
                case 4:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Completed;
                        StageImage[1].sprite = Completed;
                        StageImage[2].sprite = Completed;
                        StageImage[3].sprite = Completed;
                        StageImage[4].sprite = Normal;
                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        LevelText[1].enabled = true;
                        LevelText[2].enabled = true;
                        LevelText[3].enabled = true;
                        LevelText[4].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[1].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[2].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[3].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[4].gameObject.GetComponent<Button>().enabled = true;
                       
                    }

                    break;
                case 5:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[StageNumber].sprite = Locked;
                        StageImage[0].sprite = Completed;
                        StageImage[1].sprite = Completed;
                        StageImage[2].sprite = Completed;
                        StageImage[3].sprite = Completed;
                        StageImage[4].sprite = Completed;
                        StageImage[5].sprite = Normal;

                        LevelText[StageNumber].enabled = false;
                        LevelText[0].enabled = true;
                        LevelText[1].enabled = true;
                        LevelText[2].enabled = true;
                        LevelText[3].enabled = true;
                        LevelText[4].enabled = true;
                        LevelText[5].enabled = true;
                        StageImage[0].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[1].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[2].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[3].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[4].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[5].gameObject.GetComponent<Button>().enabled = true;
                    }

                    break;
                case 6:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[StageNumber].sprite = Completed;
                        StageImage[6].sprite = Normal;
                        StageImage[7].sprite = Locked;
                        StageImage[8].sprite = Locked;
                        StageImage[9].sprite = Locked;

                        LevelText[StageNumber].enabled = true;                      
                        LevelText[7].enabled = false;
                        LevelText[8].enabled = false;
                        LevelText[9].enabled = false;
                        StageImage[7].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[8].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[9].gameObject.GetComponent<Button>().enabled = false;
                      
                    }

                    break;
                case 7:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[StageNumber].sprite = Completed;                     
                        StageImage[7].sprite = Normal;
                        StageImage[8].sprite = Locked;
                        StageImage[9].sprite = Locked;
                        LevelText[StageNumber].enabled = true;                    
                        LevelText[8].enabled = false;
                        LevelText[9].enabled = false;
                     
                        StageImage[8].gameObject.GetComponent<Button>().enabled = false;
                        StageImage[9].gameObject.GetComponent<Button>().enabled = false;
                    }

                    break;
                case 8:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[StageNumber].sprite = Completed;
                        StageImage[8].sprite = Normal;
                        StageImage[9].sprite = Locked;
                          LevelText[StageNumber].enabled = true;                   
                        LevelText[9].enabled = false;
                        StageImage[9].gameObject.GetComponent<Button>().enabled = false;
                    }

                    break;
                case 9:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].gameObject.GetComponent<Button>().enabled = true;
                        StageImage[StageNumber].sprite = Completed;
                        StageImage[9].sprite = Normal;
                       
                        LevelText[StageNumber].enabled = true;
                        
                    }

                    break;
                case 10:
                    for (StageNumber = 0; StageNumber < StageImage.Length; StageNumber++)
                    {
                        StageImage[StageNumber].sprite = Completed;
                         LevelText[StageNumber].enabled = true;

                    }

                    break;

                default:
                    Debug.LogError("FIX SUIIII!");
                    break;
            }
        }
       
    }
    public void ProgressFunctionality(int Stagevalue)
    {

        if (Stagevalue > StageProgress)
        {
            StageProgress++;
            PlayerPrefs.SetInt("Progress", StageProgress);

            Debug.Log(StageProgress + "+" + "StageProgress2");
            Debug.Log(Stagevalue + "+" + "Stagevalue");

        }
        else
            return;
            
        
          
     
      

    }
}
