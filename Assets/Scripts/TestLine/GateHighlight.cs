using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHighlight : MonoBehaviour
{
   [SerializeField]GlowGateSSO allGlowGates;
   [SerializeField]GateType gateType;
    private Sprite old;
   public void Glow()
   {
       old = GetComponent<Image>().sprite;
       if(gateType == GateType.and)
       {
        GetComponent<Image>().sprite = allGlowGates.and;
       }
       if(gateType == GateType.or)
       {
        GetComponent<Image>().sprite = allGlowGates.or;
       }
       if(gateType == GateType.bulb)
       {
        GetComponent<Image>().sprite = allGlowGates.bulb;
        GetComponent<SwitchLight>().AlterValid();
       }
       if(gateType == GateType.batterry)
       {
        GetComponent<Image>().sprite = allGlowGates.batterry;
       }
       if(gateType == GateType.not)
       {
        GetComponent<Image>().sprite = allGlowGates.not;
       }
   }

   public void UnGlow()
   {
        GetComponent<Image>().sprite = old;
        if(gateType == GateType.bulb)
        {
         GetComponent<SwitchLight>().AlterValid();
        }
   }
}
