using UnityEngine;

public class BombExplosion : MonoBehaviour, IExplodable
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private float _explosionRange;
    [SerializeField] private float _explosionPower;

    private Rigidbody2D _rigidbody;

    public void Exploded(Vector3 explosionPosition, float explosionPower)
    {
        _rigidbody.AddForce((transform.position - explosionPosition).normalized * explosionPower, ForceMode2D.Impulse);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Invoke("Explode", _explosionDelay);
    }

    private void Explode()
    {
        RaycastHit2D[] hited = Physics2D.CircleCastAll(transform.position, _explosionRange, Vector2.zero);

        foreach (RaycastHit2D hit in hited)
        {
            if (hit.collider.gameObject.TryGetComponent<IExplodable>(out IExplodable expolodable))
            {
                expolodable.Exploded(transform.position, _explosionPower);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRange);
    }
}
