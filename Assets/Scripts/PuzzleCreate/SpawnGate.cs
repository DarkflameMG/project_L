using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnGate : MonoBehaviour,IBeginDragHandler,IDragHandler
{
    [SerializeField]private GateSO gateSO;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private Transform GateNumberSystem;
    [SerializeField]private Transform viewPort;

    private GateNumberSystem gateNumberSystem;
    private Transform gateTranform;
    private bool enable = true;
    private Canvas canvas;
    private LimitGateSys limitGateSys;
    // private bool start = false;
    private void Start() {
        GetComponent<Image>().sprite = gateSO.sprite;
        if(GateNumberSystem != null)
        {
            gateNumberSystem = GateNumberSystem.GetComponent<GateNumberSystem>();
        }
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if(GameObject.Find("LimitGateSys") != null)
        {
            limitGateSys = GameObject.Find("LimitGateSys").GetComponent<LimitGateSys>();
        }
        // Button btn = GetComponent<Button>();
        // btn.onClick.AddListener(Click);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(enable)
        {
            Spawn();
            eventData.pointerDrag = gateTranform.Find("Image").gameObject;
            gateTranform.Find("Image").gameObject.GetComponent<DragDrop>().OnBeginDragAux();
            // Debug.Log(eventData.pointerDrag.name);
        }
    }

    private void Spawn()
    {
        // Debug.Log(viewPort.position);
        if(limitGateSys != null)
        {
            limitGateSys.DecreaseNumber(gateSO.gateName);
        }
        gateTranform = Instantiate(gateSO.prefab,spawnPoint);
        if(gateNumberSystem != null)
        {
            gateTranform.gameObject.name = gateSO.gateName+"_"+gateNumberSystem.GetGateNum();
            gateTranform.localPosition = Input.mousePosition + new Vector3(-950f,-550f,0) - viewPort.localPosition;   
        }
        else
        {
            gateTranform.localPosition = Input.mousePosition + new Vector3(-1320f,0,0) - viewPort.localPosition;
        }
        gateTranform.GetComponent<GateObject>().SetPreSpawnPoint(spawnPoint);
    }

    public GateSO GetGateSO()
    {
        return gateSO;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
    
    public void SetEnable(bool data)
    {
        enable = data;
    }
}
