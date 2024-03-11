using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateNumberSetting : MonoBehaviour
{
    [SerializeField]private Image gateImg;
    [SerializeField]private TMP_Text num;
    [SerializeField]private TMP_Text gateName;
    [SerializeField]private AllGateSpriteSO allGateSpriteSO;

    public void SetGate(string gateName,int number)
    {
        this.gateName.text = gateName;
        num.text = number.ToString();
        Sprite newSprite = allGateSpriteSO.and;
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

        gateImg.sprite = newSprite;
    }

}
