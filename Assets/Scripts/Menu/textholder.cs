using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textholder : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;


    private void OnMouseOver()
    {
        Debug.Log(text.color);
        text.color = new Color(198,198,198);
    }

    private void OnMouseExit()
    {
        text.color = new Color(1, 1, 1);
    }

    public void test()
    {
        Debug.Log("Clicked...!");
    }
}
