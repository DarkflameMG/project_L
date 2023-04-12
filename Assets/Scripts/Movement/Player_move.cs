using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private LobbyInfo lobbyInfo;

    private void Start() {
        transform.position = lobbyInfo.PlayerLocation;
    }

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = Vector2To3(inputVector);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .4f;
        float playerHigh = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*playerHigh, playerRadius, moveDir, moveDistance);
        // Debug.Log(Physics.Raycast(transform.position, moveDir, playerRadius));

        if(!canMove)
        {
            //Cannot move towards moveDir
            //Attempt only X movment
            Vector3 moveDirX = new Vector3(moveDir.x,0,0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*playerHigh, playerRadius, moveDirX, moveDistance);

            if(canMove)
            {
                //Can move only on X
                moveDir = moveDirX;
            }
            else
            {
                //Attempt only Z movment
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*playerHigh, playerRadius, moveDirZ, moveDistance);
                if(canMove)
                {
                    //Can move only on Z
                    moveDir = moveDirZ;
                }
            }
        }
        if(canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        lobbyInfo.PlayerLocation = transform.position;
    }

    /* return vector 2 dimention when press key*/
    // private Vector2 VectorOnPush()
    // {
    //     Vector2 inputVector = new Vector2(0,0);
    //     if(Input.GetKey(KeyCode.W))
    //     {
    //         inputVector.y = +1;
    //     }
    //     if(Input.GetKey(KeyCode.A))
    //     {
    //         inputVector.x = -1;
    //     }
    //     if(Input.GetKey(KeyCode.S))
    //     {
    //         inputVector.y = -1;
    //     }
    //     if(Input.GetKey(KeyCode.D))
    //     {
    //         inputVector.x = +1;
    //     }
    //     return inputVector;
    // }
    
    /* tranform vector2 to vector 3 dimention*/
    private Vector3 Vector2To3(Vector2 v2)
    {
        return new Vector3(v2.x,0f,v2.y);
    }
}
