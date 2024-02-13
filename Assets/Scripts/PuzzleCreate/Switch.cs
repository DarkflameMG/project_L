using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    private bool state = false;
    private RectTransform rect;
    private bool allowLeftClick = false;

    private void Awake() {
        rect = transform.Find("Image").GetComponent<RectTransform>();
        UpdateState();
    }
    private void OnMouseOver() {
        Debug.Log("over");
        if(Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(0) && allowLeftClick))
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
        GetComponent<GateObject>().SetSwtichState(state);
    }

    public void SetAllow()
    {
        allowLeftClick = true;
    }
}
