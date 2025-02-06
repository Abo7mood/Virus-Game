using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    public Text mangascore;

    public bool gg;

    // Start is called before the first frame update
    void Start()
    {
        mangascore.text = PlayerPrefs.GetInt("manganumber4").ToString();

    }

    public void addmanga()
    {
        int manganumber = int.Parse(mangascore.text);
        manganumber = manganumber + 1;
        mangascore.text = manganumber.ToString();

    }

    public void savemanga()
    {
        int manganumber = int.Parse(mangascore.text);
        PlayerPrefs.SetInt("manganumber4", manganumber);
    }

    private void Update()
    {
        int mangascore = int.Parse("mangascore");

        if (mangascore == 10)
        {
            gg = false;
            }
    }
}
