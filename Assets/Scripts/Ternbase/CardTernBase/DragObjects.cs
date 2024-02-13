using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private Vector3 mousePosition;
    private float offsetX, offsetY, offsetZ;

    public static bool mouseButtonReleased;

    private void OnMouseDown() {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        offsetZ = Camera.main.ScreenToWorldPoint(Input.mousePosition).z - transform.position.z;
        Debug.Log("mouse down");
    }

    private void OnMouseDrag() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x - offsetX, mousePosition.y - offsetY, offsetZ);
        Debug.Log("Draging");
    }

    private void OnMouseUp() {
        mouseButtonReleased = true;
        Debug.Log("Mouse up");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        string thisGameObjectName;
        string collisionGameObjectName;

        thisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameObjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if(mouseButtonReleased && thisGameObjectName == "PokerCards" && thisGameObjectName == collisionGameObjectName){
            Instantiate(Resources.Load("PokerCards_42"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else if(mouseButtonReleased && thisGameObjectName == "Oak" && thisGameObjectName == collisionGameObjectName){
            Instantiate(Resources.Load("Rocket_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
