using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineDrawner : MonoBehaviour
{
    [SerializeField]private Transform startP;
    [SerializeField]private Transform endP;
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update() {
        if(startP && endP)
        {
            lineRenderer.SetPosition(0,startP.position);
            lineRenderer.SetPosition(1,endP.position);
        }
        else
        {
            lineRenderer.SetPosition(0,Vector3.zero);
            lineRenderer.SetPosition(1,Vector3.zero);
        }
    }
}
