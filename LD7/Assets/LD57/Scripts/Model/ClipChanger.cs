using UnityEngine.Events;

public static class ClipChanger
{
    public static event UnityAction ClipEnded;

    public static event UnityAction ClipChanged;

    public static void ClipEndedActivation()
    {
        ClipEnded.Invoke();
    }
}
