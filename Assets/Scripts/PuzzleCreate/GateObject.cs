using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObject : MonoBehaviour
{
    [SerializeField]private GateSO gateSO;
    [SerializeField]private bool isHolder = false;
    [SerializeField]private Transform s1;
    [SerializeField]private Transform s2;
    [SerializeField]private Transform output;
    private string gateName;
    private void Awake() {
        gateName = gateSO.gateName;
    }
    private bool currentState = false;
    private bool slot1 = false;
    private bool slot2 = false;
    private bool switchState = false;
    private bool isPuzzleStart = false;
    private Transform holder;
    private Transform holded;

    public GateSO GetGateSO()
    {
        return gateSO;
    }

    public bool GetCurrentState()
    {
        return currentState;
    }

    public void SetSwtichState(bool state)
    {
        switchState = state;
    }

    private void Update() {
        if(gateName.Equals("battery"))
        {
            currentState = true;
        }
        else if(gateName.Equals("bulb"))
        {
            currentState = slot1;
        }
        else if(gateName.Equals("not"))
        {
            currentState = !slot1;
        }
        else if(gateName.Equals("and"))
        {
            currentState = slot1 && slot2;
        }
        else if(gateName.Equals("switch"))
        {
            if(switchState)
            {
                currentState = slot1;
            }
            else
            {
                currentState = false;
            }
        }


        if(holder != null)
        {
            GetComponent<RectTransform>().anchoredPosition = holder.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void SetSlot1(bool value)
    {
        slot1 = value;
    }
    public void SetSlot2(bool value)
    {
        slot2 = value;
    }

    public bool GetIsPuzzle()
    {
        return isPuzzleStart;
    }

    public void SetIsPuzzle(bool value)
    {
        isPuzzleStart = value;
    }

    public void SetHolder(Transform holder)
    {
        this.holder = holder;
    }
    public void SetHolded(Transform holded)
    {
        this.holded = holded;
    }

    public Transform GetHolded()
    {
        return holded;
    }
    public Transform GetHolder()
    {
        return holder;
    }

    public bool GetIsHolder()
    {
        return isHolder;
    }

    public Transform GetS1()
    {
        return s1;
    }

    public Transform GetS2()
    {
        return s2;
    }

    public Transform GetOutput()
    {
        return  output;
    }

    public void HideSlot()
    {
        if(s1 != null)
        {
            s1.gameObject.SetActive(false);
        }

        if(s2 != null)
        {
            s2.gameObject.SetActive(false);
        }

        if(output != null)
        {
            output.gameObject.SetActive(false);
        }
    }

    public void UnHideSlot()
    {
        if(s1 != null)
        {
            s1.gameObject.SetActive(true);
        }

        if(s2 != null)
        {
            s2.gameObject.SetActive(true);
        }

        if(output != null)
        {
            output.gameObject.SetActive(true);
        }
    }
}
