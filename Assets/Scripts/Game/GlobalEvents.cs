using System;


public static class GlobalEvents 
{
    public static event Action OnSceneClean;

    public static void CleanScene() => OnSceneClean?.Invoke();
}
