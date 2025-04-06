using UnityEngine;

public class FrogoWheeli : EnemyAbstract
{
    [SerializeField] private float _speed;
    [SerializeField] private int _direction; // -1 для правого направления
    [SerializeField] private float _border;

    private float _startPositionX;

    internal void Initialize(float speed, int direction)
    {
        _speed = speed;
        _direction = direction;
        _startPositionX = transform.position.x;
        _border = -_startPositionX;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed * _direction;

        if (_direction == 1 && _border - transform.position.x > -0.05f) Destroy(gameObject);
        if (_direction == -1 && _border - transform.position.x < 0.05f) Destroy(gameObject);
    }
}
