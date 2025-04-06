using UnityEngine;

public class CrockodiloBombordinoShooting : EnemyAbstract
{
    [SerializeField] private GameObject _bombPrefab;

    private int _direction;

    public void Initialize(float bombardiniDelay, int direction)
    {
        // bombardiniDelay - задержка перед началом сброса бомб
        // bombardiniRepeatRate - переодичность сброса бомб
        _direction = direction;
        Invoke("SpawnBomb", bombardiniDelay);
    }

    private void SpawnBomb()
    {
        Instantiate(_bombPrefab, transform.position + Vector3.right * _direction, transform.rotation)
            .GetComponent<Rigidbody2D>()
            .AddForce(Vector3.right * _direction * Random.Range(0.1f,1));

        Invoke("DestroyMyself", 1);
    }

    private void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
