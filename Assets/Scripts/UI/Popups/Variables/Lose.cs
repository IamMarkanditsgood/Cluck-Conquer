using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : BasicPopup
{
    public Button restart;
    public Button home;

    public GameScreen gameScreen;

    private void Start()
    {
        restart.onClick.AddListener(Restart);
        home.onClick.AddListener(Home);
    }

    private void OnDestroy()
    {
        restart.onClick.RemoveListener(Restart);
        home.onClick.RemoveListener(Home);
    }

    public override void SetPopup()
    {
    }

    public override void ResetPopup()
    {
    }
    private void Restart()
    {
        Debug.Log(gameScreen);
        gameScreen.RestartGame();
        Hide();
    }

    private void Home()
    {
       
        gameScreen.Home();
        Hide();
    }
}
