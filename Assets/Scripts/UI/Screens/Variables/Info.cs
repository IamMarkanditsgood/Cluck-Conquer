using UnityEngine.UI;

public class Info : BasicScreen
{
    public Button close;

    private void Start()
    {
        close.onClick.AddListener(Close);
    }

    private void OnDestroy()
    {
        close.onClick.RemoveListener(Close);
    }
    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }
}
