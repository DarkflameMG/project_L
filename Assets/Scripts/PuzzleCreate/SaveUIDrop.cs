using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveUIDrop : MonoBehaviour, IDropHandler
{
    [SerializeField]private Transform gateCountPrefab;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private AllGateSpriteSO allGateSpriteSO;
    private List<string> gatesName;
    private void Awake() {
        gatesName = new();
    }
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log(eventData.pointerDrag.name);
        Transform gate = eventData.pointerDrag.transform.parent;
        if(eventData.pointerDrag != null && gate.tag == "saveable")
        {
            GateObject gateObject = gate.GetComponent<GateObject>();
            string gateName = gateObject.GetGateName();
            Debug.Log(gateObject.GetGateName());
            if(!gatesName.Contains(gateName))
            {
                gatesName.Add(gateName);
                Transform gateConfig = Instantiate(gateCountPrefab,spawnPoint);
                gateConfig.GetComponent<LogicGateCounter>().SetName(gateName);
                gateConfig.Find("name").GetComponent<TMP_Text>().text = gateName;
                Sprite newSprite = gateConfig.Find("Image").GetComponent<Image>().sprite;

                if(gateName.Equals("and"))
                {
                    newSprite = allGateSpriteSO.and;
                }
                else if(gateName.Equals("or"))
                {
                    newSprite = allGateSpriteSO.or;
                }
                else if(gateName.Equals("not"))
                {
                    newSprite = allGateSpriteSO.not;
                }
                else if(gateName.Equals("xor"))
                {
                    newSprite = allGateSpriteSO.xor;
                }
                else if(gateName.Equals("nand"))
                {
                    newSprite = allGateSpriteSO.nand;
                }
                else if(gateName.Equals("nor"))
                {
                    newSprite = allGateSpriteSO.nor;
                }
                else if(gateName.Equals("xnor"))
                {
                    newSprite = allGateSpriteSO.xnor;
                }
                else if(gateName.Equals("high volt"))
                {
                    newSprite = allGateSpriteSO.highVolt;
                }
                else if(gateName.Equals("low volt"))
                {
                    newSprite = allGateSpriteSO.lowVolt;
                }
                else if(gateName.Equals("switch"))
                {
                    newSprite = allGateSpriteSO.switchs;
                }
                else if(gateName.Equals("bulb"))
                {
                    newSprite = allGateSpriteSO.bulb;
                }
                else if(gateName.Equals("splitter"))
                {
                    newSprite = allGateSpriteSO.splitter;
                }
                else if(gateName.Equals("placeholder1"))
                {
                    newSprite = allGateSpriteSO.placeHolder1;
                }
                else if(gateName.Equals("placeholder2"))
                {
                    newSprite = allGateSpriteSO.placeHolder2;
                }
                else if(gateName.Equals("line"))
                {
                    newSprite = allGateSpriteSO.line;
                }

                gateConfig.Find("Image").GetComponent<Image>().sprite = newSprite;

            }
            Destroy(gate.gameObject);
        }
    }
}
