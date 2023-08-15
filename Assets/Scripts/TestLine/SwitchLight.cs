using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLight : MonoBehaviour
{
    private Image img;
    [SerializeField]private Sprite off;
    [SerializeField]private Sprite on;
    private GateObject gateObject;
    private void Awake() {
        img = GetComponent<Image>();
    }

    private void Update() {
        gateObject = transform.parent.GetComponent<GateObject>();
        if(gateObject.GetCurrentState())
        {
            img.sprite = on;
        }
        else
        {
            img.sprite = off;
        }
    }
}
