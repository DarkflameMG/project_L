using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 7f;

    private void Update() {
        Vector2 inputVector = VectorOnPush();
        
        inputVector = inputVector.normalized;
        Vector3 moveDir = Vector2To3(inputVector);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private Vector2 VectorOnPush()
    {
        Vector2 inputVector = new Vector2(0,0);
        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        return inputVector;
    }

    private Vector3 Vector2To3(Vector2 v2)
    {
        return new Vector3(v2.x,0f,v2.y);
    }
}
