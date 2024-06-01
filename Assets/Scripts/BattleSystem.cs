using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform PlayerBattleground;
    public Transform EnemyBattleground;

    public Text dialogueText;
    Unit playerUnit;
    Unit enemyUnit;
    
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;

        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, PlayerBattleground);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, EnemyBattleground);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + "\n approaches...";

    }
}
