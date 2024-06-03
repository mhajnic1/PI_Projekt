using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject[] playerPrefab;
    public GameObject[] enemyPrefab;
    public Transform[] PlayerBattleground;
    public Transform[] EnemyBattleground;
    public Text dialogueText;
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    Unit[] playerUnit;
    Unit[] enemyUnit;
    
    public BattleState state;
    // Postavimo state na start - početak combat-a
    void Start()
    {
        state = BattleState.START;

        playerUnit = new Unit[PlayerBattleground.Length];
        enemyUnit = new Unit[EnemyBattleground.Length];

        // koristimo coroutine da čekamo
        StartCoroutine(SetupBattle());
    }

    // Instanciramo player i enemy unit-e te započnemo igračev turn
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab[0], PlayerBattleground[0]);
        playerUnit[0] = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab[0], EnemyBattleground[0]);
        enemyUnit[0] = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit[0].unitName + "\n approaches...";

        playerHUD.SetHUD(playerUnit[0]);
        enemyHUD.SetHUD(enemyUnit[0]);

        // čekamo dvije sekunde
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    
    // ENEMY TURN
    IEnumerator EnemyTurn(){
        //TODO
        //Implementirati kompletnu logiku borbe
        dialogueText.text = enemyUnit[0].unitName + " attacks!";

        yield return new WaitForSeconds(2f);

        bool isDead = playerUnit[0].TakeDamage(enemyUnit[0].damage);

        playerHUD.setHP(playerUnit[0].currentHP);
        yield return new WaitForSeconds(2f);
        

        if(isDead){
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    // PLAYER TURN
    void PlayerTurn(){
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton(){
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHeal(){
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerAttack(){

            // Napasti neprijatelja
            bool isDead = enemyUnit[0].TakeDamage(playerUnit[0].damage);

            enemyHUD.setHP(enemyUnit[0].currentHP);
            dialogueText.text = "The attack is successful!";
            yield return new WaitForSeconds(2f);

            //Provjeriti ako je neprijatelj mrtav
            if(isDead){
                //Kraj bitke
                state = BattleState.WON;
                EndBattle();
            } else {
                //Neprijatelj je na redu
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            // Promjeniti state igre zavisno od rezultata 
        }
    IEnumerator PlayerHeal(){
        playerUnit[0].Heal(5);

        playerHUD.setHP(playerUnit[0].currentHP);
        dialogueText.text = "You feel better!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    // GAME STATE
    // TODO
    // Implementirati popup pri pobjedi/porazu
    void EndBattle(){
            if(state == BattleState.WON){
                dialogueText.text = "You won the battle!";
            } else if (state == BattleState.LOST){
                dialogueText.text = "You lost the battle :(";
            }
        }
}
