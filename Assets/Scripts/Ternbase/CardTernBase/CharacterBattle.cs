using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    public Sprite player;

    public Vector3 GetPosition(){
        return transform.position;
    }

    public void Attack(CharacterBattle targetCharacterBattle){
        Vector3 attackDir = (targetCharacterBattle.GetPosition() - GetPosition()).normalized;
        
    }
}
