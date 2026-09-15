using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action onTakeDamage;
    public static event Action<GameObject> onDie ;
    [SerializeField]
    private float MaxHealth = 10;
    [SerializeField]
    private float health;
    public bool isDefeated => health == 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }
    public void dealDmg(float dmgDealt)
    {
        if (health == 0)
        {
            return;
        }
        onTakeDamage?.Invoke();
        health = Mathf.Max(health - dmgDealt, 0);
        if (health <= 0)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("death");
            if (this.gameObject.tag == "Player")
            {
                GameState.Instance.playerLost();
            }
            if (this.gameObject.tag == "Enemy")
            {
                GameState.Instance.playerWon();
            }
        }
    }
    public float getMaxHealth() => MaxHealth;
    public float getCurrentHealth() => health;

    public void setHealth(float updatedHealth)
    {
        health = updatedHealth;
    }

    public void setMaxHP(float updatedMaxHP)
    {
        MaxHealth = updatedMaxHP;
    }
}
