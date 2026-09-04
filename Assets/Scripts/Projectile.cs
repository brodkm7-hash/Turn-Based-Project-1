using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 1.5f;
    [SerializeField] int damageAmt = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health hp))
        {
            hp.dealDmg(damageAmt);
        }
    }
}
