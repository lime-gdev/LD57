using UnityEngine;

public class LevelBootStrap : MonoBehaviour
{
    [SerializeField] private ClipsManager clipsManager;

    [SerializeField] private float _difficulty;

    void Start()
    {
        LevelScenarioGenerator levelGenerator = new LevelScenarioGenerator();

        ClipScenario[] scenarios = levelGenerator.Generate(_difficulty);

        MainScreenLevelScenario levelScenario = new MainScreenLevelScenario();
        foreach (ClipScenario clip in scenarios)
        {
            levelScenario.AddLevelScenario(clip);
        }

        clipsManager.Initialize(levelScenario);
    }
}
