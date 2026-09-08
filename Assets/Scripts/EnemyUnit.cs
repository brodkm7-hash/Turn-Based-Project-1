using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EnemyUnit : Unit
{
    Dictionary<int, AnimationClip[]> attackTypes = new Dictionary<int, AnimationClip[]>();
    public AnimationClip[] meleeList;
    public AnimationClip[] rangedList;
    public string[] attackList;
    public float percentage;

    private float speed = 10.0f;
    private Vector2 startingPos;
    private int selectedAttack;

    public override void Start()
    {
        base.Start();
        percentage = health.getCurrentHealth() / health.getMaxHealth();
        healthbar_img.fillAmount = percentage;
        startingPos = transform.position;
        attackTypes.Add(0, meleeList);
        attackTypes.Add(1, rangedList);
        Health.onDie += enemyDeath;
    }

   

    void Update()
    {
        percentage = health.getCurrentHealth() / health.getMaxHealth();
        healthbar_img.fillAmount = percentage;
        if (isAttacking == true)
        {
            startAttack();
        }
    }

    public Health getHealthValue()
    {
        return health;
    }

    IEnumerator Hurt()
    {
        unitAnimator.SetTrigger("hit");
        yield return new WaitForSeconds(1f);
        unitAnimator.SetTrigger("idle");
    }
    private void OnEnable()
    {
        Health.onTakeDamage += Health_onTakeDamage;
    }

    
    private void Health_onTakeDamage()
    {
        StartCoroutine(Hurt());
    }

    public void startAttack()
    {
        if (GameState.Instance.PlayerPrefab != null)
        {
            selectedAttack = Random.Range(0, 2);
            StartCoroutine(attackEnemy(attackList[selectedAttack]));
        }
    }

    IEnumerator attackEnemy(string attackName)
    {
        GameObject playerRef = GameState.Instance.PlayerPrefab;
        if (selectedAttack == 0 || selectedAttack == 2)
        {
            float distance = Vector2.Distance(transform.position, playerRef.transform.position);
            while (distance > 1.5f)
            {
                float walk = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, playerRef.transform.position, walk);
                distance = Vector2.Distance(transform.position, playerRef.transform.position);
                yield return null; //had to look this up bc it was frozen without it
            }
        }
        unitAnimator.Play(attackName);
        yield return new WaitForSeconds(1f);
        unitAnimator.SetTrigger("idle");
        if (selectedAttack == 0 || selectedAttack == 2)
        {
            while (Vector2.Distance(transform.position, startingPos) > 0.05f && isAttacking == true)
            {
                float walk = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, startingPos, walk);
            }
            transform.position = startingPos;
        }
        unitAnimator.SetTrigger("idle");
        isAttacking = false;
        GameState.Instance.endEnemyState();
    }
    private void OnDisable()
    {
        Health.onTakeDamage -= Health_onTakeDamage;
        Health.onDie -= enemyDeath;
    }
    private void enemyDeath(float healthValue)
    {
        if (health.getCurrentHealth() == healthValue)
        {
            return;
        }
        Debug.Log("Health value is " + healthValue + "Object name is " + this.gameObject.name);
        unitAnimator.SetTrigger("death");
        GameState.Instance.playerWon();
    }
}