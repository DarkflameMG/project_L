using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnGate : MonoBehaviour//,IPointerClickHandler
{
    [SerializeField]private GateSO gateSO;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private Transform GateNumberSystem;

    private GateNumberSystem gateNumberSystem;
    // private bool start = false;
    private void Start() {
        GetComponent<Image>().sprite = gateSO.sprite;
        gateNumberSystem = GateNumberSystem.GetComponent<GateNumberSystem>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    private void Click()
    {
        Debug.Log("click");
        Transform gateTranform = Instantiate(gateSO.prefab,spawnPoint);
        gateTranform.gameObject.name = gateSO.gateName+"_"+gateNumberSystem.getGateNum();
        gateTranform.localPosition = Vector3.zero;
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     // throw new System.NotImplementedException();
    //     click();
    // }
    public GateSO GetGateSO()
    {
        return gateSO;
    }
}
