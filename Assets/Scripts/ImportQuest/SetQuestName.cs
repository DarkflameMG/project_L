using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuestName : MonoBehaviour
{
    private Transform child;
    public void setQuestName(string name)
    {
        child = transform.GetChild(1);
        child.GetComponent<TMPro.TextMeshProUGUI>().text = name;
    }
}
