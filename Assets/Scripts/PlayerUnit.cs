using UnityEngine;
using System.Collections;
using System;

public class PlayerUnit : Unit, IDisposable
{
    public GameObject enemyRef;
    private float speed = 10.0f;
    //private Vector2 target; use for multiple enemies in a fight
    private Vector2 pos;
    private Camera cam;
    public Transform startingPos;
    public float percentage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        pos = gameObject.transform.position;
        cam = Camera.main;
        Health.onDie += onDeathLoss;
    }

    

    IEnumerator attackEnemy()
    {
        unitAnimator.SetTrigger("attack");
        yield return new WaitForSeconds(1f);
        unitAnimator.SetTrigger("idle");
        transform.position = startingPos.position;
    }

    public void dealDamage()
    {
        if (GameState.Instance.EnemyPrefab != null)
        {
            enemyRef = GameState.Instance.EnemyPrefab;
            enemyRef.GetComponent<EnemyUnit>().getHealthValue().dealDmg(damageAmount); 
            
        }

    }
    public void startAttack()
    {
        if (GameState.Instance.EnemyPrefab != null)
        {
            enemyRef = GameState.Instance.EnemyPrefab;
        }
        float Distance = Vector2.Distance(transform.position, enemyRef.transform.position);
        if (Distance > 0.5f && isAttacking == true)
        {
            moveToTarget();
        }  
        else
        {
            StartCoroutine(attackEnemy());
            isAttacking = false;
            GameState.Instance.endPlayerState();
        }
    }

    private void moveToTarget()
    {
        float walk = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, enemyRef.transform.position, walk);
    }

    private void onDeathLoss(float healthValue)
    {
        if (health.getCurrentHealth() == healthValue)
        {
            return;
        }
        unitAnimator.SetTrigger("death");
        GameState.Instance.playerLost();
    }
    // Update is called once per frame
    void Update()
    {
        percentage = health.getCurrentHealth() / health.getMaxHealth();
        healthbar_img.fillAmount = percentage;
        if (isAttacking == true) {
            startAttack();
        }
    }

    public void Dispose()
    {
        Health.onDie -= onDeathLoss;
    }
}
