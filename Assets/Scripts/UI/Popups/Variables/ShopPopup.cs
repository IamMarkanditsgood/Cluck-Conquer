using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : BasicPopup
{
    public TMP_Text text;
    public Image chicken;

    public Sprite[] chickens;

    private int _chickenIndex;

    public void Init(int chickenIndex)
    {
        _chickenIndex = chickenIndex;
    }

    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
        text.text = "You bought \n Chicken" + (_chickenIndex +1);
        chicken.sprite = chickens[_chickenIndex];
    }
}
