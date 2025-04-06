using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject crockodiloBombordinoPrefab;
    [SerializeField] private GameObject frogoWheeliPrefab;

    [SerializeField] private ClipsManager clipsManager;

    private ClipScenario _clipScenario;
    private Timer _timer;

    [SerializeField] private Enemy _enemy;
    [SerializeField] private bool _isWaiting;

    private bool _initialized = false;

    public void Initialize(ClipScenario scenario)
    {
        _timer = new Timer();
        _timer.StartTimer();
        _initialized = true;
        _clipScenario = scenario;
    }

    private void Update()
    {
        if (!_initialized) return;

        _timer.UpdateTimer();

        if (!_isWaiting) _enemy = _clipScenario.GetNextAction();

        print(_enemy);

        if (_enemy != null)
        {
            print(_enemy);
            if (_enemy.SpawnDelay <= _timer.GetCurrentTime()) 
            {
                print("Time");
                if (_enemy is Crockodilo croc)
                {
                    SpawnCrock(croc);
                }                
                if (_enemy is Frogo frog)
                {
                    print("aaa");
                    SpawnFrog(frog);
                }
                _enemy = null;
                _isWaiting = false;
            }
            else
            {
                _isWaiting = true;
            }
        }
        else
        {
            print("Stop");
            StopClip();
        }
    }


    private void SpawnCrock(Crockodilo crockodilo)
    {
        Instantiate(crockodiloBombordinoPrefab, crockodilo.SpawnPoint, transform.rotation)
            .GetComponent<CrockodiloBombordinoShooting>()
            .Initialize(crockodilo.BombardiniDelay, crockodilo.Direction);
    }

    private void SpawnFrog(Frogo frog)
    {
        Vector3 fwspawnPosition = new Vector3(3.4f, -3.8f, 10);

        Instantiate(frogoWheeliPrefab, frog.SpawnPoint, transform.rotation)
            .GetComponent<FrogoWheeli>()
            .Initialize(frog.Speed, frog.Direction);
    }

    private void StopClip()
    {
        clipsManager.ChangeClip();

        _initialized = false;
    }
}
