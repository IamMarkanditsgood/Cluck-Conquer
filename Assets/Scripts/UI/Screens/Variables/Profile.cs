using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : BasicScreen
{
    public TMP_Text name;
    public TMP_InputField inputField;
    public TMP_Text totalPurchased;
    public TMP_Text LevelTimeDone;
    public TMP_Text Wins;
    public TMP_Text Loses;

    public Button info;
    public Button close;
    public Button editName;
    public Button avatar;

    public AvatarManager avatarManager;

    private void Start()
    {
        info.onClick.AddListener(Info);
        close.onClick.AddListener(Close);
        editName.onClick.AddListener(EditName);
        avatar.onClick.AddListener(Avatar);
    }

    private void OnDestroy()
    {
        info.onClick.RemoveListener(Info);
        close.onClick.RemoveListener(Close);
        editName.onClick.RemoveListener(EditName);
        avatar.onClick.RemoveListener(Avatar);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Name", inputField.text);
        PlayerPrefs.Save();
    }

    public override void SetScreen()
    {
        Configure();
    }

    public override void ResetScreen()
    {
        inputField.gameObject.SetActive(false);
        name.gameObject.SetActive(true);
        name.text = inputField.text;
    }

    private void Configure()
    {
        name.text = PlayerPrefs.GetString("Name", "UserName");
        inputField.text = PlayerPrefs.GetString("Name", "UserName");

        totalPurchased.text = PlayerPrefs.GetInt("TotalPuechase").ToString();
        LevelTimeDone.text = PlayerPrefs.GetInt("LevelTimeDone").ToString();
        Wins.text = PlayerPrefs.GetInt("Wins").ToString();
        Loses.text = PlayerPrefs.GetInt("Loses").ToString();
    }

    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }
    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }
    private void EditName()
    {
        if(!inputField.gameObject.activeInHierarchy)
        {
            inputField.gameObject.SetActive(true);
            name.gameObject.SetActive(false);
        }
        else
        {
            inputField.gameObject.SetActive(false);
            name.gameObject.SetActive(true);
            name.text = inputField.text;
        }
    }
    private void Avatar()
    {
        avatarManager.PickFromGallery();
    }

   
}