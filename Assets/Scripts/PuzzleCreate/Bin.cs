using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.GetChild(0).GetComponent<GateHighlight>() != null)
        {
            other.GetComponent<RectTransform>().localScale = new Vector3(1.3f,1.3f,1.3f);
            other.transform.GetChild(0).GetComponent<GateHighlight>().Glow();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.GetChild(0).GetComponent<GateHighlight>() != null)
        {
            other.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            other.transform.GetChild(0).GetComponent<GateHighlight>().UnGlow();
        }
    }
}
