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
    private Transform preSpawnPoint;

    private void OnMouseDown() {
        Debug.Log(gateName +" "+ currentState +" slot"+slot1);
    }

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
        if(gateName.Equals("high volt"))
        {
            currentState = true;
        }
        else if(gateName.Equals("line") || gateName.Equals("splitter"))
        {
            currentState = slot1;
        }
        else if(gateName.Equals("bulb") || gateName.Equals("output"))
        {
            currentState = slot1;
        }
        else if(gateName.Equals("not"))
        {
            NotOp();
        }
        else if(gateName.Equals("and"))
        {
            AndOp();
        }
        else if(gateName.Equals("or"))
        {
            OrOp();
        }
        else if(gateName.Equals("xor"))
        {
            XorOp();
        }
        else if(gateName.Equals("nor"))
        {
            OrOp();
            currentState = !currentState;
        }
        else if(gateName.Equals("nand"))
        {
            AndOp();
            currentState = !currentState;
        }
        else if(gateName.Equals("xnor"))
        {
            XorOp();
            currentState = !currentState;
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
        else if(gateName.Equals("placeholder1"))
        {
            Holder1Op();
        }
        else if(gateName.Equals("placeholder2"))
        {
            Holder2Op();
        }

        if(holder != null)
        {
            GetComponent<RectTransform>().anchoredPosition = holder.GetComponent<RectTransform>().anchoredPosition;
        }
    }
    private void NotOp()
    {
        currentState = !slot1;
    }
    private void AndOp()
    {
        currentState = slot1 && slot2;
    }
    private void OrOp()
    {
        currentState = slot1 || slot2;
    }
    private void XorOp()
    {
        currentState = slot1 != slot2;
    }
    private void Holder2Op()
    {
        if(holded != null)
        {
            GateObject holdGate = holded.GetComponent<GateObject>();
            string name = holdGate.GetGateName();
            if(name.Equals("and"))
            {
                AndOp();
            }
            else if(name.Equals("or"))
            {
                OrOp();
            }
            else if(name.Equals("nand"))
            {
                AndOp();
                currentState = !currentState;
            }
            else if(name.Equals("nor"))
            {
                OrOp();
                currentState = !currentState;
            }
            else if(name.Equals("xor"))
            {
                XorOp();
            }
            else if(name.Equals("xnor"))
            {
                XorOp();
                currentState = !currentState;
            }
        }
        else
        {
            currentState = false;
        }
    }
    private void Holder1Op()
    {
        if(holded != null)
        {
            GateObject holdGate = holded.GetComponent<GateObject>();
            string name = holdGate.GetGateName();
            if(name.Equals("not"))
            {
                NotOp();
            }
            else if(name.Equals("line"))
            {
                currentState = slot1;
            }
        }
        else
        {
            currentState = false;
        }
    }
    public string GetGateName()
    {
        return gateName;
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

    public void SetPreSpawnPoint(Transform point)
    {
        preSpawnPoint = point;
        Debug.Log("set "+preSpawnPoint);
    }

    public Transform GetPreSpawnPoint()
    {
        return preSpawnPoint;
    }

    public void SetState(bool data)
    {
        currentState = data;
    }
}
