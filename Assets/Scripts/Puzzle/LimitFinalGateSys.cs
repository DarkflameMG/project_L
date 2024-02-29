using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitFinalGateSys : MonoBehaviour
{
    [SerializeField]private GameObject and;
    [SerializeField]private GameObject not;
    [SerializeField]private GameObject or;
    // [SerializeField]private GameObject line;
    [SerializeField]private GameObject xor;
    [SerializeField]private GameObject nand;
    [SerializeField]private GameObject nor;
    [SerializeField]private GameObject xnor;
    [SerializeField]private GateInventorySO gateInventorySO;
    private int andNum;
    private int notNum;
    private int orNum;
    // private int lineNum;
    private int xorNum;
    private int nandNum;
    private int norNum;
    private int xnorNum;

    public void SetStartNum()
    {
        // Debug.Log(name);
        if(gateInventorySO.and > 0)
        {
            andNum = gateInventorySO.and;
            and.SetActive(true);
            and.GetComponent<SpawnGate>().SetEnable(true);
        }
        if(gateInventorySO.not > 0)
        {
            notNum = gateInventorySO.not;
            not.SetActive(true);
            not.GetComponent<SpawnGate>().SetEnable(true);
        }
        if(gateInventorySO.or > 0)
        {
            orNum = gateInventorySO.or;
            or.SetActive(true);
            or.GetComponent<SpawnGate>().SetEnable(true);
        }
        // else if(name.Equals("line"))
        // {
        //     lineNum = num;
        //     line.SetActive(true);
        //     line.GetComponent<SpawnGate>().SetEnable(true);
        // }
        if(gateInventorySO.xor > 0)
        {
            xorNum = gateInventorySO.xor;
            xor.SetActive(true);
            xor.GetComponent<SpawnGate>().SetEnable(true);
        }
        if(gateInventorySO.nand > 0)
        {
            nandNum = gateInventorySO.nand;
            nand.SetActive(true);
            nand.GetComponent<SpawnGate>().SetEnable(true);
        }
        if(gateInventorySO.nor > 0)
        {
            norNum = gateInventorySO.nor;
            nor.SetActive(true);
            nor.GetComponent<SpawnGate>().SetEnable(true);
        }
        if(gateInventorySO.xnor > 0)
        {
            xnorNum = gateInventorySO.xnor;
            xnor.SetActive(true);
            xnor.GetComponent<SpawnGate>().SetEnable(true);
        }
        SetText();
    }

    private void SetText()
    {
        and.transform.Find("number").GetComponent<TMP_Text>().text = andNum.ToString();
        not.transform.Find("number").GetComponent<TMP_Text>().text = notNum.ToString();
        or.transform.Find("number").GetComponent<TMP_Text>().text = orNum.ToString();
        // line.transform.Find("number").GetComponent<TMP_Text>().text = lineNum.ToString();
        xor.transform.Find("number").GetComponent<TMP_Text>().text = xorNum.ToString();
        nand.transform.Find("number").GetComponent<TMP_Text>().text = nandNum.ToString();
        nor.transform.Find("number").GetComponent<TMP_Text>().text = norNum.ToString();
        xnor.transform.Find("number").GetComponent<TMP_Text>().text = xnorNum.ToString();
    }

    public void DecreaseNumber(string name)
    {
        GameObject currentSpawner = and;
        int currentNum = 0;
        if(name.Equals("and"))
        {
            andNum--;
            currentNum =andNum;
            currentSpawner = and;
        }
        else if(name.Equals("not"))
        {
            notNum--;
            currentNum = notNum;
            currentSpawner = not;
        }
        else if(name.Equals("or"))
        {
            orNum--;
            currentNum = orNum;
            currentSpawner = or;
        }
        // else if(name.Equals("line"))
        // {
        //     lineNum--;
        //     currentNum = lineNum;
        //     currentSpawner = line;
        // }
        else if(name.Equals("xor"))
        {
            xorNum--;
            currentNum = xorNum;
            currentSpawner = xor;
        }
        else if(name.Equals("nand"))
        {
            nandNum--;
            currentNum = nandNum;
            currentSpawner = nand;
        }
        else if(name.Equals("nor"))
        {
            norNum--;
            currentNum = norNum;
            currentSpawner = nor;
        }
        else if(name.Equals("xnor"))
        {
            xnorNum--;
            currentNum = xnorNum;
            currentSpawner = xnor;
        }

        SetText();
        if(currentNum <=0)
        {
            currentSpawner.GetComponent<SpawnGate>().SetEnable(false);
        }
    }

    public void IncreaseNumber(string name)
    {
        Debug.Log("Increase "+name);
        GameObject currentSpawner = and;
        if(name.Equals("and"))
        {
            andNum++;
            currentSpawner = and;
        }
        else if(name.Equals("not"))
        {
            notNum++;
            currentSpawner = not;
        }
        else if(name.Equals("or"))
        {
            orNum++;
            currentSpawner = or;
        }
        // else if(name.Equals("line"))
        // {
        //     lineNum++;
        //     currentSpawner = line;
        // }
        else if(name.Equals("xor"))
        {
            xorNum++;
            currentSpawner = xor;
        }
        else if(name.Equals("nand"))
        {
            nandNum++;
            currentSpawner = nand;
        }
        else if(name.Equals("nor"))
        {
            norNum++;
            currentSpawner = nor;
        }
        else if(name.Equals("xnor"))
        {
            xnorNum++;
            currentSpawner = xnor;
        }
        SetText();
        currentSpawner.GetComponent<SpawnGate>().SetEnable(true);
    }

    public void ResetGate(bool data)
    {
        and.SetActive(data);
        or.SetActive(data);
        not.SetActive(data);
        // line.SetActive(data);
        xor.SetActive(data);
        nand.SetActive(data);
        nor.SetActive(data);
        xnor.SetActive(data);
    }
}
