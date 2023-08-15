using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    private bool state = false;
    private RectTransform rect;

    private void Awake() {
        rect = GetComponent<RectTransform>();
        UpdateState();
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1))
        {
            state = !state;
            Debug.Log(state);
            UpdateState();
        }
    }
    
    private void Update() {
        if(state)
        {
            rect.localRotation = Quaternion.Euler(0f, 0f,90f);
        }
        else
        {
            rect.localRotation = Quaternion.Euler(0f, 0f,0f);
        }
    }

    private void UpdateState()
    {
        transform.parent.GetComponent<GateObject>().SetSwtichState(state);
    }
}
