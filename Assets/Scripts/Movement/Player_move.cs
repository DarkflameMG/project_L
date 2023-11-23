using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private LobbyInfo lobbyInfo;
    public Animator animator;
    public float groundDist;
    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    private void Start() {
        transform.position = lobbyInfo.PlayerLocation;
        lobbyInfo.Busy = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = Vector2To3(inputVector);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .4f;
        float playerHigh = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*playerHigh, playerRadius, moveDir, moveDistance);
        // Debug.Log(Physics.Raycast(transform.position, moveDir, playerRadius));
        if(!lobbyInfo.Busy)
        {
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
        }
        lobbyInfo.PlayerLocation = transform.position;

        //2.5D code

        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir3 = new Vector3(x,0,y);
        rb.velocity = moveDir3 * moveSpeed;

        if(x != 0 || y != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        

        //Animator RUN
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 7f;
            Debug.Log("Left Shift key was pressed");
            animator.SetBool("run", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
            Debug.Log("Left Shift key was released");
            animator.SetBool("run", false);
        }
        //Animator ATTACK
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed");
            animator.SetBool("attack", true);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was pressed");
            animator.SetBool("attack", false);
        }
        
        if(x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if(x != 0 && x > 0)
        {
            sr.flipX = false;
        }


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
