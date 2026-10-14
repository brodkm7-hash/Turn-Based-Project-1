using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject throwable;
    [SerializeField] Transform launchPoint;
    [SerializeField] float projectileSpd;
    private AudioSource attackSound;


    public void launchProjectile()
    {
        GameObject throwVal = Instantiate(throwable, launchPoint.position, Quaternion.identity);
        Debug.Log("launched");
        if (throwVal.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.linearVelocity = launchPoint.right * projectileSpd;
        }
        attackSound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            launchProjectile();
        }
    }
}
