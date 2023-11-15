using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragView : MonoBehaviour
{
    [SerializeField]private Transform viewPort;
    private void Update() {
        transform.localPosition = viewPort.localPosition;
    }
}
