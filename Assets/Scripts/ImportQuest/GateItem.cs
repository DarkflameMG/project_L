using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateItem : MonoBehaviour
{
    [SerializeField]private TMP_Text count;
    [SerializeField]private GateInventorySO gateInventorySO;
    [SerializeField]private string gateName;

    private void SetCount(int num)
    {
        count.text = "[ "+num.ToString()+" ]";
        gameObject.SetActive(true);
    } 

    public void Check()
    {
        if(gateName.Equals("and"))
        {
            if(gateInventorySO.and > 0)
            {
                SetCount(gateInventorySO.and);
            }
        }
        else if(gateName.Equals("or"))
        {
            if(gateInventorySO.or > 0)
            {
                SetCount(gateInventorySO.or);
            }
        }
        else if(gateName.Equals("not"))
        {
            if(gateInventorySO.not > 0)
            {
                SetCount(gateInventorySO.not);
            }
        }
        else if(gateName.Equals("xor"))
        {
            if(gateInventorySO.xor > 0)
            {
                SetCount(gateInventorySO.xor);
            }
        }
        else if(gateName.Equals("nand"))
        {
            if(gateInventorySO.nand > 0)
            {
                SetCount(gateInventorySO.nand);
            }
        }
        else if(gateName.Equals("nor"))
        {
            if(gateInventorySO.nor > 0)
            {
                SetCount(gateInventorySO.nor);
            }
        }
        else if(gateName.Equals("xnor"))
        {
            if(gateInventorySO.xnor > 0)
            {
                SetCount(gateInventorySO.xnor);
            }
        }
        else if(gateName.Equals("highVolt"))
        {
            if(gateInventorySO.highVolt > 0)
            {
                SetCount(gateInventorySO.highVolt);
            }
        }
        else if(gateName.Equals("lowVolt"))
        {
            if(gateInventorySO.lowVolt > 0)
            {
                SetCount(gateInventorySO.lowVolt);
            }
        }
        else if(gateName.Equals("switch"))
        {
            if(gateInventorySO.switchs > 0)
            {
                SetCount(gateInventorySO.switchs);
            }
        }
        else if(gateName.Equals("bulb"))
        {
            if(gateInventorySO.bulb > 0)
            {
                SetCount(gateInventorySO.bulb);
            }
        }
        else if(gateName.Equals("splitter"))
        {
            if(gateInventorySO.splitter > 0)
            {
                SetCount(gateInventorySO.splitter);
            }
        }
        else if(gateName.Equals("placeHolder1"))
        {
            if(gateInventorySO.placeHolder1 > 0)
            {
                SetCount(gateInventorySO.placeHolder1);
            }
        }
        else if(gateName.Equals("placeHolder2"))
        {
            if(gateInventorySO.placeHolder2 > 0)
            {
                SetCount(gateInventorySO.placeHolder2);
            }
        }
        else if(gateName.Equals("line"))
        {
            if(gateInventorySO.line > 0)
            {
                SetCount(gateInventorySO.line);
            }
        }
    }
}
