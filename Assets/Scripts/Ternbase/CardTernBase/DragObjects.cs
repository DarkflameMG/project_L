using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    private void OnMouseDown() {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp() {
        mouseButtonReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        string thisGameObjectName;
        string collisionGameObjectName;

        thisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameObjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if(mouseButtonReleased && thisGameObjectName == "Acorn" && thisGameObjectName == collisionGameObjectName){
            Instantiate(Resources.Load("Oak_object"), transform.position, Quaternion.identity);
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
