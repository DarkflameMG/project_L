using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 3;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
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
        Vector3 moveDir = new Vector3(x,0,y);
        rb.velocity = moveDir * speed;

        animator.SetFloat("speed", Mathf.Abs(x * speed));

        //Animator RUN
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10;
            Debug.Log("Left Shift key was pressed");
            animator.SetBool("run", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3;
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
}
