using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fading : MonoBehaviour
{
    [Header("FadeParts")]

    [SerializeField] Image[] fadingImages;
    [SerializeField] Text fadingtext;
    Color myColor1;
    Color myColor2;
    Color myColor3;

    [Header("Speed")]
    [Tooltip("Speed")]
    [SerializeField] float speed;
    bool isfade=true;
    private void Start()
    {
        myColor1 = fadingImages[0].color;
        myColor2= fadingImages[1].color;
        myColor3 = fadingtext.color;
    }
    private void Update()
    {
        if (isfade)
        {
            fadingImages[0].color = new Color(myColor1.r, myColor1.g, myColor1.b, myColor1.a-=speed * Time.deltaTime);
            fadingImages[1].color = new Color(myColor2.r, myColor2.g, myColor2.b,myColor2.a-=speed * Time.deltaTime);
            fadingtext.color = new Color(myColor3.r, myColor3.g, myColor3.b, myColor3.a -= speed * Time.deltaTime);
        }

        if (fadingImages[0].color.a<=0|| fadingImages[1].color.a <= 0|| fadingtext.color.a <= 0)
        isfade = false;
    }
}
