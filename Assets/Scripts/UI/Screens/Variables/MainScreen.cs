using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : BasicScreen
{
    public TMP_Text _name;
    public TMP_Text _score;

    public Button play;
    public Button profile;
    public Button shop;
    public Button info;
    public Button achievements;

    private void Start()
    {
        play.onClick.AddListener(PlayGame);
        profile.onClick.AddListener(Profile);
        shop.onClick.AddListener(Shop);
        info.onClick.AddListener(Info);
        achievements.onClick.AddListener(Achievements);
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(PlayGame);
        profile.onClick.RemoveListener(Profile);
        shop.onClick.RemoveListener(Shop);
        info.onClick.RemoveListener(Info);
        achievements.onClick.RemoveListener(Achievements);
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
        ConfigureScreen();
    }

    private void ConfigureScreen()
    {
        _name.text = PlayerPrefs.GetString("Name", "UserName");
        _score.text = PlayerPrefs.GetInt("Score").ToString();
    }

    private void PlayGame()
    {
        GameScreen gameScreen = (GameScreen)UIManager.Instance.GetScreen(ScreenTypes.Game);
        gameScreen.StartGame(); 
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
    }

    private void Profile()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }

    private void Shop()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Shop);
    }

    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }

    private void Achievements()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Achievements);
    }
}