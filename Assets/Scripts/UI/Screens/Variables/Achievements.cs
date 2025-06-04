using UnityEngine;
using UnityEngine.UI;

public class Achievements : BasicScreen
{
    public Button[] achievements;

    public Button close;

    private void Start()
    {
        close.onClick.AddListener(Close);

        for(int i = 0; i < achievements.Length; i++)
        {
            int index = i;
            achievements[index].onClick.AddListener(() => Get(index));
        }
    }

    private void OnDestroy()
    {
        close.onClick.RemoveListener(Close);

        for (int i = 0; i < achievements.Length; i++)
        {
            int index = i;
            achievements[index].onClick.RemoveListener(() => Get(index));
        }
    }
    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {

        for (int i = 0; i < achievements.Length; i++)
        {
            string key = "Achieve" + i;

            if(PlayerPrefs.GetInt(key) == 1)
            {
                achievements[i].gameObject.SetActive(true);
                achievements[i].interactable = true;
            }
            else if(PlayerPrefs.GetInt(key) == 2)
            {
                achievements[i].gameObject.SetActive(false);
            }
            else
            {
                achievements[i].gameObject.SetActive(true);
                achievements[i].interactable = false;
            }
        }
    }

    private void Get(int index)
    {
        int newScore = PlayerPrefs.GetInt("Score") + 100;
        PlayerPrefs.SetInt("Score", newScore);

        string key = "Achieve" + index;
        PlayerPrefs.SetInt(key, 2);

        SetScreen();
    }
    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }
}
