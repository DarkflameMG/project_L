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
        else if(this.gateName.Equals("not"))
        {
            newSprite = allGateSpriteSO.not;
        }
        else if(this.gateName.Equals("xor"))
        {
            newSprite = allGateSpriteSO.xor;
        }
        else if(this.gateName.Equals("nand"))
        {
            newSprite = allGateSpriteSO.nand;
        }
        else if(this.gateName.Equals("nor"))
        {
            newSprite = allGateSpriteSO.nor;
        }
        else if(this.gateName.Equals("xnor"))
        {
            newSprite = allGateSpriteSO.xnor;
        }
        else if(this.gateName.Equals("high volt"))
        {
            newSprite = allGateSpriteSO.highVolt;
        }
        else if(this.gateName.Equals("low volt"))
        {
            newSprite = allGateSpriteSO.lowVolt;
        }
        else if(this.gateName.Equals("switch"))
        {
            newSprite = allGateSpriteSO.switchs;
        }
        else if(this.gateName.Equals("bulb"))
        {
            newSprite = allGateSpriteSO.bulb;
        }
        else if(this.gateName.Equals("splitter"))
        {
            newSprite = allGateSpriteSO.splitter;
        }
        else if(this.gateName.Equals("placeholder1"))
        {
            newSprite = allGateSpriteSO.placeHolder1;
        }
        else if(this.gateName.Equals("placeholder2"))
        {
            newSprite = allGateSpriteSO.placeHolder2;
        }
        else if(this.gateName.Equals("line"))
        {
            newSprite = allGateSpriteSO.line;
        }

        gateImg.sprite = newSprite;
    }

}
