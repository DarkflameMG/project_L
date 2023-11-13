using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroolWheelSys : MonoBehaviour
{
    [SerializeField]private RectTransform viewPoint;
    [SerializeField]private float zoomRate = 5f;
    private void Update() {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWheel != 0)
        {
            WheelZoom(scrollWheel);
        }
    }

    private void WheelZoom(float scrollWheel)
    {
        float rate = 1 + zoomRate * Time.unscaledDeltaTime;
        if(scrollWheel > 0)
        {
            StartZoom(viewPoint.localScale.y * rate);
        }
        else if(scrollWheel < 0)
        {
            StartZoom(viewPoint.localScale.y / rate);
        }
    }

    private void StartZoom(float scale)
    {
        viewPoint.localScale = new Vector3(scale,scale,1);
    }
}
