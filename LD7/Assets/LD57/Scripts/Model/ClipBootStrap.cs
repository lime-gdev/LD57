using UnityEngine;

public class ClipBootStrap : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private ClipScenario _scenario;

    public void Initialize(ClipScenario clipScenario)
    {
        _playerMovement.Initialize();

        _scenario = clipScenario;
        //_scenario.AddAction(new Crockodilo(2, new Vector3(2, 2, 10), 1, 2));
        //_scenario.AddAction(new Frogo(1, new Vector3(3.4f, -3.8f, 10), 4, 1));
        //_scenario.AddAction(new Frogo(5, new Vector3(-3.4f, -3.8f, 10), 4, -1));

        _enemySpawner.Initialize(_scenario);
    }
}
