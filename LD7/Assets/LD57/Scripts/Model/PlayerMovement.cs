using UnityEngine;

public class PlayerMovement : MonoBehaviour, IExplodable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _verticalBorder;
    [SerializeField] private float _horizontalBorder;


    private Rigidbody2D _rigidbody;
    private bool _initialized;
    private bool _jumped = false;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initialized = true;

        ClipChanger.ClipEnded += StopClip;
    }

    public void Exploded(Vector3 explosionPosition, float explosionPower)
    {
        _rigidbody.AddForce((transform.position - explosionPosition).normalized * explosionPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (!_initialized) return;

        CheckBorders();

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * horizontalInput * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && !_jumped)
        {
            _jumped = true;
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void CheckBorders()
    {
        if (transform.position.x >= _verticalBorder)
        {
            transform.position = new Vector3(-_verticalBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -_verticalBorder)
        {
            transform.position = new Vector3(_verticalBorder, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= _horizontalBorder)
        {
            transform.position = new Vector3(transform.position.x, _horizontalBorder-0.1f, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Floor>() != null)
        {
            _jumped = false;
        }
    }

    private void StopClip()
    {
        _initialized = false;

        ClipChanger.ClipEnded -= StopClip;
    }
}
