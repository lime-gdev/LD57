using System.Collections.Generic;

public class MainScreenLevelScenario
{
    Queue<ClipScenario> mainScreenLevelScenario = new Queue<ClipScenario>();

    public ClipScenario GetNextClip()
    {
        if(mainScreenLevelScenario.Count > 0) return mainScreenLevelScenario.Dequeue();
        return null;
    }

    public void AddLevelScenario(ClipScenario clipScenario)
    {
        mainScreenLevelScenario.Enqueue(clipScenario);
    }
}
