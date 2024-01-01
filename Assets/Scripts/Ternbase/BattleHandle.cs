using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private SpriteRenderer enemy;

    private void Start() {
        SpawnCharacter(true, player);
        SpawnCharacter(false, enemy);
    }

    private void SpawnCharacter(bool isPlayerTeam, SpriteRenderer character){
        Vector3 position;
        if(isPlayerTeam){
            position = new Vector3(-15, 4, -17);
        }else{
            character.flipX = true;
            position = new Vector3(+15, 4, -17);
        }
        Instantiate(character, position, Quaternion.identity);
    }

}
