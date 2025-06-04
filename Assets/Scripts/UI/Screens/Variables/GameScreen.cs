using UnityEngine.UI;

public class GameScreen : BasicScreen
{
    public HorizontalDrag horizontalDrag;
    public ChickenController chickenController;

    public Button pause;

    private void Start()
    {
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

    private void Pause()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Pause);
    }

    public void StartGame()
    {
        horizontalDrag.isActive = true;
        chickenController.isActive = true;
    }

    public void FinishGame()
    {
        horizontalDrag.isActive = false;
        chickenController.isActive = false;
    }

    public void RestartGame()
    {
    }
}
