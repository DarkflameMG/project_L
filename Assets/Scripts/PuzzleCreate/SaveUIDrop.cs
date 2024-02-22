using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveUIDrop : MonoBehaviour, IDropHandler
{
    [SerializeField]private Transform gateCountPrefab;
    [SerializeField]private Transform spawnPoint;
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log(eventData.pointerDrag.name);
        Transform gate = eventData.pointerDrag.transform.parent;
        if(eventData.pointerDrag != null && gate.tag == "saveable")
        {
            Debug.Log(gate.name);
            Destroy(gate.gameObject);
        }
    }
}
