using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
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
    public BattleHUD[] playerHUD;
    public BattleHUD[] enemyHUD;
    public GameObject deadPrefab;
    public Animator[] animatorenemy;
    public Animator[] animatorplayer;
    Unit[] playerUnit;
    Unit[] enemyUnit;

    public int k = 0;
    public int z = 0;
    public int randomNumber;
    public int lastNumber;

    public BattleState state;
    // Postavimo state na start - početak combat-a
    void Start()
    {
        state = BattleState.START;

        playerUnit = new Unit[PlayerBattleground.Length];
        enemyUnit = new Unit[EnemyBattleground.Length];
        animatorenemy = new Animator[EnemyBattleground.Length];

        // koristimo coroutine da čekamo
        StartCoroutine(SetupBattle());
    }

    // Instanciramo player i enemy unit-e te započnemo igračev turn
    IEnumerator SetupBattle()
    {
        for(int i = 0; i < 3; i++){
        GameObject playerGO = Instantiate(playerPrefab[i], PlayerBattleground[i]);
        playerUnit[i] = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab[i], EnemyBattleground[i]);
        enemyUnit[i] = enemyGO.GetComponent<Unit>();

         //animatorplayer[i] = playerUnit[i].GetComponent<Animator>();
        animatorenemy[i] = enemyUnit[i].GetComponent<Animator>();
        playerHUD[i].SetHUD(playerUnit[i]);
        enemyHUD[i].SetHUD(enemyUnit[i]);
        }

       
        dialogueText.text = "A wild " + enemyUnit[0].unitName + "\n approaches...";
        // čekamo dvije sekunde
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn(k);

    }

    
    // ENEMY TURN
    IEnumerator EnemyTurn(int z){
        // mrtvi ne mogu napadati
       /* int counter = 0;
        while(enemyUnit[z].currentHP <= 0){
            z++;
            if(z == 3) z = 0;counter++;
            if(counter > 6) state = BattleState.LOST; EndBattle();
        }
       */
        dialogueText.text = enemyUnit[z].unitName + " attacks!";

        yield return new WaitForSeconds(2f);

        // triggeramo animaciju za napad
        animatorenemy[z].ResetTrigger("idle");
        animatorenemy[z].SetTrigger("attack");

        // ne mozemo napasti mrtvu metu
        int broj = NewRandomNumber();
        Boolean provjera = true;
        while(provjera){
                if(playerUnit[broj].currentHP <= 0){
                    broj++;
                    if(broj == 3) broj = 0;
                    print("zapeo u while provjeri");
                } else {
                    provjera = false;
                }
            }
        
        /*while(playerUnit[broj].currentHP <= 0){
            broj = NewRandomNumber();
        }*/
        bool isDead = playerUnit[broj].TakeDamage(enemyUnit[z].damage);

        if(playerUnit[broj].currentHP <= 0) playerUnit[broj].currentHP = 0;
        playerHUD[broj].setHP(playerUnit[broj].currentHP);
        
        yield return new WaitForSeconds(2f);
        

        if(/*playerUnit[broj].currentHP < 0*/isDead){
            int provjera2 = 0;
            for(int i = 0; i < 3; i++){
                provjera2 += playerUnit[i].currentHP;
            }
            print(provjera2);
            if(provjera2 <= 0){
                state = BattleState.LOST;
                EndBattle();
            } else {
            state = BattleState.PLAYERTURN;
            if(k == 2) {k = 0;} else{ k++;}
            PlayerTurn(k);
            }
        } else {
            state = BattleState.PLAYERTURN;
            if(k == 2) {k = 0;} else{ k++;}
            PlayerTurn(k);
        }
    }

    // PLAYER TURN
    void PlayerTurn(int k){
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton(){
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack(k));
    }

    public void OnHeal(){
        if (state != BattleState.PLAYERTURN) return;
        if(k == 2) {k = 0;} else{ k++;}
        StartCoroutine(PlayerHeal(k));
    }
 
    IEnumerator PlayerAttack(int k){
        //int counter = 0; 
        /*
            while(playerUnit[k].currentHP <= 0){
                k++;
                if(k == 3) k = 0; counter++;
                if(counter > 6) state = BattleState.LOST; EndBattle();
            }
            counter = 0;*/
            int broj = NewRandomNumber();
            // ne mozes napasti mrtvog lika
            
            Boolean provjera = true;

            while(provjera){
                if(enemyUnit[broj].currentHP <= 0){
                    broj++;
                    if(broj == 3) broj = 0;
                    print("zapeo u while provjeri");
                } else {
                    provjera = false;
                }
            }

            // Napasti neprijatelja
            bool isDead = enemyUnit[broj].TakeDamage(playerUnit[k].damage);
            if(enemyUnit[broj].currentHP <= 0) enemyUnit[broj].currentHP = 0;
            enemyHUD[broj].setHP(enemyUnit[broj].currentHP);
            
            dialogueText.text = "The attack is successful!";
            yield return new WaitForSeconds(2f);

            //Provjeriti ako je neprijatelj mrtav
            if(/*enemyUnit[broj].currentHP < 0*/isDead){
                //Kraj bitke
            
            // triggerati animaciju za smrt
            animatorenemy[broj].ResetTrigger("idle");
            animatorenemy[broj].SetTrigger("death");
            if(z == 2) {z = 0;} else{ z++;}
            int provjera2 = 0;
            for(int i = 0; i < 3; ++i){
                provjera2 += enemyUnit[i].currentHP;
            }
            print(provjera2);
            if(provjera2 <= 0){
                state = BattleState.WON;
                EndBattle();
            } else {
            state = BattleState.ENEMYTURN;
            if(z == 2) {z = 0;} else{ z++;}
            StartCoroutine(EnemyTurn(z));
            }
            } else {
                //Neprijatelj je na redu
                state = BattleState.ENEMYTURN;
                if(z == 2) {z = 0;} else{ z++;}
                StartCoroutine(EnemyTurn(z));
            }
            // Promjeniti state igre zavisno od rezultata 
        }
    IEnumerator PlayerHeal(int k){
        playerUnit[k].Heal(5);

        playerHUD[k].setHP(playerUnit[k].currentHP);
        dialogueText.text = "You feel better!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        if(z == 2) {z = 0;} else{ z++;}
        StartCoroutine(EnemyTurn(z));
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

    public int NewRandomNumber()
{
    randomNumber =  UnityEngine.Random.Range(0,3);

    if (randomNumber == lastNumber)
    {
        randomNumber =  UnityEngine.Random.Range(0,3);
    }

    lastNumber = randomNumber;
    return randomNumber;
}
}
