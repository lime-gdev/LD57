using UnityEngine;

public class LevelScenarioGenerator
{
    public ClipScenario[] Generate(float difficulty)
    {
        ClipScenario clipScenario1 = new ClipScenario();

        clipScenario1.AddAction(new Crockodilo(1,new Vector3(-3.2f, 4.2f,10), 1, 1));
        clipScenario1.AddAction(new Crockodilo(3,new Vector3(3.2f, 4.2f,10), 1, -1));
        clipScenario1.AddAction(new Crockodilo(5,new Vector3(-3.2f, 4.2f,10), 1, 1));
        clipScenario1.AddAction(new Crockodilo(7,new Vector3(3.2f, 4.2f,10), 1, -1));        
        
        ClipScenario clipScenario2 = new ClipScenario();

        clipScenario2.AddAction(new Frogo(1, new Vector3(-3.4f, -3.8f, 10), 4, -1));
        clipScenario2.AddAction(new Frogo(3, new Vector3(3.4f, -3.8f, 10), 4, 1));
        clipScenario2.AddAction(new Frogo(5, new Vector3(-3.4f, -3.8f, 10), 4, -1));
        clipScenario2.AddAction(new Frogo(7, new Vector3(3.4f, -3.8f, 10), 4, 1));

        ClipScenario[] result = new ClipScenario[2] { clipScenario1, clipScenario2};

        return result;
    }
}