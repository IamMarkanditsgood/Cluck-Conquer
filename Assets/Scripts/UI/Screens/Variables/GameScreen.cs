using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BasicScreen
{
    public HorizontalDrag horizontalDrag;
    public ChickenController chickenController;
    public EnemyController enemyController;
    public PlayerBase playerBase;
    public Obstacle[] obstacles;

    public Button pause;

    private Coroutine timer;
    private int time;

    private void Start()
    {
        Time.timeScale = 0;
        pause.onClick.AddListener(Pause);
    }

    private void OnDestroy()
    {
        pause.onClick.RemoveListener(Pause);
    }
    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        UIManager.Instance.ShowPopup(PopupTypes.Pause);
    }

    public void StartGame()
    {
        Time.timeScale = 1;


        horizontalDrag.isActive = true;
        chickenController.Toggle(true);
        enemyController.Toggle(true);
        playerBase.Toggle(true);

        foreach (var obstacle in obstacles)
        {
            obstacle.StartGame();
        }
        time = 0;
        timer = StartCoroutine(Timer());
    }

    public void FinishGame(bool isWin)
    {
        GlobalEvents.CleanScene();  
        Time.timeScale = 0;
        horizontalDrag.isActive = false;
        chickenController.Toggle(false);
        enemyController.Toggle(false);
        playerBase.Toggle(false);
        StopCoroutine(timer);

        if(isWin)
        {
            UIManager.Instance.ShowPopup(PopupTypes.Win);

            string key = "Achieve" + 0;
            PlayerPrefs.SetInt(key, 1);

            key = "Achieve" + 5;
            PlayerPrefs.SetInt(key, 1);

            int win = PlayerPrefs.GetInt("Win");
            win++;
            PlayerPrefs.SetInt("Win", win);

            if(time < PlayerPrefs.GetInt("LevelTimeDone",10000))
            {
                PlayerPrefs.SetInt("LevelTimeDone", time);
            }
        }

        else
        {
            int lose = PlayerPrefs.GetInt("Lose");
            lose++;
            PlayerPrefs.SetInt("Lose", lose);

            UIManager.Instance.ShowPopup(PopupTypes.Lose);
        }
    }

    public void RestartGame()
    {
        GlobalEvents.CleanScene();
        horizontalDrag.isActive = false;
        chickenController.Toggle(false);
        enemyController.Toggle(false);
        playerBase.Toggle(false);
        
        StartGame();
    }

    public void Home()
    {
        GlobalEvents.CleanScene();
        horizontalDrag.isActive = false;
        chickenController.Toggle(false);
        enemyController.Toggle(false);
        playerBase.Toggle(false);

        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}
