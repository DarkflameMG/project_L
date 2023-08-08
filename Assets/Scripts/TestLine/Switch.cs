using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("left Click");
        }
    }
    
}
