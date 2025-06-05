using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : BasicPopup
{
    public Button pause;
    public Button restart;
    public Button home;

    public GameScreen gameScreen;

    private void Start()
    {
        pause.onClick.AddListener(PausePressed);
        restart.onClick.AddListener(Restart);
        home.onClick.AddListener(Home);
    }

    private void OnDestroy()
    {
        pause.onClick.RemoveListener(PausePressed);
        restart.onClick.RemoveListener(Restart);
        home.onClick.RemoveListener(Home);
    }

    public override void SetPopup()
    {
    }

    public override void ResetPopup()
    {
    }
    private void PausePressed()
    {
       
        gameScreen.Pause();
        Hide();
    }
    private void Restart()
    {
        
        gameScreen.RestartGame();
        Hide();
    }

    private void Home()
    {
       
        gameScreen.Home();
        Hide();
    }
}
