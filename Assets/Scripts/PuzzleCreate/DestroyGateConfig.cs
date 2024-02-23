using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyGateConfig : MonoBehaviour
{
    Button btn;
    private SaveUIDrop saveUIDrop;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DestroyConfig);
        if(GameObject.Find("DropZone") != null)
        {
            saveUIDrop = GameObject.Find("DropZone").GetComponent<SaveUIDrop>();
        }
    }

    private void DestroyConfig()
    {
        string gateName = transform.parent.GetComponent<LogicGateCounter>().GetName();
        saveUIDrop.DeletedGate(gateName);
        Destroy(transform.parent.gameObject);
    }
}
