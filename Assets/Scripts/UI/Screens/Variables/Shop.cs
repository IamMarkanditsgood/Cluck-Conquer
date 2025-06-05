using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : BasicScreen
{
    public Button close;
    public Button[] buy;
    public Button[] use;
    public Button[] selected;
    public int[] prices;
    public TMP_Text[] pricesText;

    public Image mainChicken;
    public Sprite[] chickens;

    private void Start()
    {
        string key = "Chicken" + 0;
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

        close.onClick.AddListener(Close);

        for (int i = 0; i < buy.Length; i++)
        {
            int index = i;
            buy[index].onClick.AddListener(() => Buy(index));
        }
        for (int i = 0; i < use.Length; i++)
        {
            int index = i;
            use[index].onClick.AddListener(() => Use(index));
        }
    }

    private void OnDestroy()
    {
        close.onClick.RemoveListener(Close);

        for (int i = 0; i < buy.Length; i++)
        {
            int index = i;
            buy[index].onClick.RemoveListener(() => Buy(index));
        }
        for (int i = 0; i < use.Length; i++)
        {
            int index = i;
            use[index].onClick.RemoveListener(() => Use(index));
        }
    }

    public override void SetScreen()
    {
        for (int i = 0; i < buy.Length; i++)
        {
            buy[i].gameObject.SetActive(true);
            use[i].gameObject.SetActive(false);
        }

        for(int i = 0; i <  pricesText.Length; i++)
        {
            pricesText[i].text = prices[i].ToString();
        }
        Configure();
    }

    public override void ResetScreen()
    {
    }

    private void Configure()
    {
        for(int i = 0; i < buy.Length; i++)
        {
            string key = "Chicken" + i;
            if(PlayerPrefs.GetInt(key) == 1)
            {
                buy[i].gameObject.SetActive(false);
                use[i].gameObject.SetActive(true);
            }
        }


        int currentChicken = PlayerPrefs.GetInt("CurrentChicken");
        buy[currentChicken].gameObject.SetActive(false);
        use[currentChicken].gameObject.SetActive(false);

        mainChicken.sprite = chickens[currentChicken];
    }

    private void Buy(int index)
    {
        int score = PlayerPrefs.GetInt("Score");

        if (score >= prices[index])
        {
            score -= prices[index];
            PlayerPrefs.SetInt("Score", score);

            string key = "Chicken" + index;
            PlayerPrefs.SetInt(key, 1);
            SetScreen();

            ShopPopup popup = (ShopPopup)  UIManager.Instance.GetPopup(PopupTypes.ShopPopup);
            popup.Init(index);
            UIManager.Instance.ShowPopup(PopupTypes.ShopPopup);

            int TotalPuechase = PlayerPrefs.GetInt("TotalPuechase");
            TotalPuechase++;
            PlayerPrefs.SetInt("TotalPuechase", TotalPuechase);
        }
    }

    private void Use(int index)
    {
        string key = "Chicken" + index;
       

        if (PlayerPrefs.GetInt(key, 1) == 1)
        {
            PlayerPrefs.SetInt("CurrentChicken", index);
            SetScreen();
        }
    }

    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }

}
