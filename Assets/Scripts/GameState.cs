using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public enum turnState {START, PLAYERTURN, ENEMYTURN, WIN, LOSE};
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    Unit Player;
    Unit Enemy;
    public TextMeshProUGUI gameText;
    public turnState state;
    public bool isPlayerTurn;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    IEnumerator Setup()
    {
        Player = PlayerPrefab.GetComponent<Unit>();
        Enemy = EnemyPrefab.GetComponent<Unit>();
        yield return new WaitForSeconds(2f);
        state = turnState.PLAYERTURN;
        isPlayerTurn = true;
        playerTurn();
    }

    public void endPlayerState()
    {
        state = turnState.ENEMYTURN;
        EnemyPrefab.GetComponent<EnemyUnit>().isAttacking = true;
    }

    public void endEnemyState()
    {
        state = turnState.PLAYERTURN;
    }

    public void playerTurn ()
    {
        gameText.text = "Choose one of the four actions.";
    }

    public void playerEscape ()
    {
        if (state != turnState.PLAYERTURN)
        {
            return;
        }
        state = turnState.LOSE;
        if (PlayerPrefab != null)
        {
            PlayerPrefab.GetComponent<Animator>().SetTrigger("death");
            gameText.text = "Fight Failed!";
        }
    }

    public void playerAttackState ()
    {
        if (state != turnState.PLAYERTURN)
        {
            return;
        }
        if (PlayerPrefab != null)
        {
            PlayerPrefab.GetComponent<PlayerUnit>().isAttacking = true;
        }
    }

    public void enemyAttackState()
    {
        if (state != turnState.ENEMYTURN)
        {
            return;
        }
        if (EnemyPrefab != null && PlayerPrefab != null)
        {
            EnemyPrefab.GetComponent<EnemyUnit>().isAttacking = true;
            EnemyPrefab.GetComponent<EnemyUnit>().startAttack();
        }
    }

    public void playerWon()
    {
        state = turnState.WIN;
    }

    public void playerLost()
    {
        state = turnState.LOSE;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = turnState.START;
        StartCoroutine(Setup());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current State: " + state);
        //Debug.Log("Is player's turn? " + isPlayerTurn);
    }
}
