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
    [SerializeField]private Transform output2;
    private string gateName;
    private void Awake() {
        gateName = gateSO.gateName;
    }
    private bool currentState = false;
    private bool slot1 = false;
    private bool slot2 = false;
    private bool s1Signal = false;
    private bool s2Signal = false;
    private bool switchState = false;
    private bool isPuzzleStart = false;
    private Transform holder;
    private Transform holded;
    private Transform preSpawnPoint;
    private FinalPuzzleCheck finalPuzzleCheck;

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

    public void AddFinalPuzzleCheckObserver(FinalPuzzleCheck puzzleCheck)
    {
        finalPuzzleCheck = puzzleCheck;
    }

    public void ResetObserver()
    {

    }

    public IEnumerator NotifyNextLine(SlotNo slotNo)
    {
        if(slotNo == SlotNo.s1)
        {
            s1Signal = true;
        }
        else if(slotNo == SlotNo.s2)
        {
            s2Signal = true;
        }

        // 0 input 1 output  or 1 input 1 output
        if(output != null && output2 == null && s2 == null)
        {
            Slot outputSlot = output.GetComponent<Slot>();
            LineV2 lineV2 = outputSlot.GetCurrentLine().Find("Line").GetComponent<LineV2>();
            lineV2.NotifyNextGate();
            // Debug.Log(outputSlot.GetCurrentLine());
        }
        // 1 input 2 output
        else if(output != null && output2 != null && s2 == null && s1 != null)
        {
            Slot outputSlot = output.GetComponent<Slot>();
            Slot outputSlot2 = output2.GetComponent<Slot>();
            LineV2 lineV2 = outputSlot.GetCurrentLine().Find("Line").GetComponent<LineV2>();
            LineV2 lineV2_2 = outputSlot2.GetCurrentLine().Find("Line").GetComponent<LineV2>();
            lineV2.NotifyNextGate();
            lineV2_2.NotifyNextGate();
        }
        // 1 output 0 output
        else if(output == null && output2 == null && s1 != null && s2 == null)
        {
            Debug.Log("output null");
            currentState = slot1;
            finalPuzzleCheck.Observe();
        }
        // 2 input 1 output
        else if(output != null && output2 == null && s1 != null && s2 != null)
        {
            if(slotNo == SlotNo.s1)
            {
                // Debug.Log("slot 1 : "+s1Signal+"slot 2 "+s2Signal);
                Debug.Log("slot 1 "+s1Signal+" slot 2 "+s2Signal);
                yield return new WaitUntil(() => s2Signal);

                s1Signal = false;
                s2Signal = false;
                Slot outputSlot = output.GetComponent<Slot>();
                LineV2 lineV2 = outputSlot.GetCurrentLine().Find("Line").GetComponent<LineV2>();
                lineV2.NotifyNextGate();
            }
            else
            {
                Debug.Log("slot 2 "+s2Signal);
            }
        }
        yield return null;
    }
}
