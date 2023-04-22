using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnGate : MonoBehaviour//,IPointerClickHandler
{
    [SerializeField]private GateSO gateSO;
    [SerializeField]private Transform spawnPoint;

    // private bool start = false;
    private void Start() {
        GetComponent<Image>().sprite = gateSO.sprite;
        // if(!start)
        // {
        //     click();
        //     start = true;
        // }
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(click);
    }

    private void click()
    {
        Debug.Log("click");
        Transform gateTranform = Instantiate(gateSO.prefab,spawnPoint);
        gateTranform.localPosition = Vector3.zero;
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     // throw new System.NotImplementedException();
    //     click();
    // }
}
