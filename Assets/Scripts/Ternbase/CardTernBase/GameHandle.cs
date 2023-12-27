using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    HealthSystem playerhealthSystem;
    HealthSystem enemyhealthSystem;
    public Animator Player;
    public Animator Enemy;
    public TMP_Text text;
    public GameObject Popup;
    private void Start()
    {
        Popup.SetActive(false);
        playerhealthSystem = new HealthSystem(100);
        enemyhealthSystem = new HealthSystem(100);
        playerHealthBar.Setup(playerhealthSystem);
        enemyHealthBar.Setup(enemyhealthSystem);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && playerhealthSystem.GetHealth() != 0 && enemyhealthSystem.GetHealth() != 0){
            playerAttack();
            if(enemyhealthSystem.GetHealth() != 0) enemyAttack();
        }
        //Player.SetBool("Attack",false);
    }

    public void playerAttack(){
        //Player.SetBool("Attack",true);
        float randomFloat = Random.Range(0.0f, 1.0f);
        enemyhealthSystem.Damage((int)(randomFloat*100));
        StartCoroutine(waiter());
        if(enemyhealthSystem.GetHealth() == 0){
            Popup.SetActive(true);
            text.text = "Player Win..";
            enemy.SetActive(false);
        }
    }

    public void enemyAttack(){
        float randomFloat = Random.Range(0.0f, 1.0f);
        playerhealthSystem.Damage((int)(randomFloat*100));
        if(playerhealthSystem.GetHealth() == 0){
            Popup.SetActive(true);
            text.text = "Player Dead..";
            player.SetActive(false);
        }
    }

    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
    }

}
