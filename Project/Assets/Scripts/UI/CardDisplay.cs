using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] Text Name;
    [SerializeField] Text PriceAmount;
    [SerializeField] Image CharacterImage;
    [SerializeField] Image WeaponImage;

    private void Start()
    {
        Name.text = card.Name;
        PriceAmount.text = card.Price.ToString();
        CharacterImage.sprite = card.CharacterImage;
        WeaponImage.sprite = card.WeaponImage;
    }
}
