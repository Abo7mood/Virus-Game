using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject BackGround;
    [SerializeField] Slider slider;
    [SerializeField] Text ProgressText;


    private void Awake()
    {
        LoadingScreen = GameObject.Find("Canvas").transform.Find("LoadingScreen").gameObject;
        BackGround = LoadingScreen.transform.Find("Slider").transform.Find("Background").gameObject;
        slider = LoadingScreen.transform.Find("Slider").gameObject.GetComponent<Slider>();
        ProgressText = slider.transform.Find("Fill Area").transform.Find("ProgressText").GetComponent<Text>();
    }
    public void LoadSceneFight(int sceneIndex)
    {
        StartCoroutine(LoadSync(sceneIndex));
        if(BackGround!=null)
        BackGround.SetActive(false);
        if (LoadingScreen != null)
            LoadingScreen.SetActive(true);
    }
    IEnumerator LoadSync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            ProgressText.text = progress * 100f + "%";
         
            yield return null;


        }
    }
  
   

    public void Menu() => SceneManager.LoadScene(0);

    public void Quit() => Application.Quit();

    void Start()
    {      
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
}
