using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitGateSys : MonoBehaviour
{
    [SerializeField]private GameObject and;
    [SerializeField]private GameObject not;
    [SerializeField]private GameObject or;
    [SerializeField]private GameObject line;
    private int andNum;
    private int notNum;
    private int orNum;
    private int lineNum;

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
        else if(name.Equals("line"))
        {
            lineNum--;
            currentNum = lineNum;
            currentSpawner = line;
        }
        SetText();
        if(currentNum <=0)
        {
            currentSpawner.GetComponent<SpawnGate>().SetEnable(false);
        }
    }

    public void IncreaseNumber(string name)
    {
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
        else if(name.Equals("line"))
        {
            lineNum++;
            currentSpawner = line;
        }
        SetText();
        currentSpawner.GetComponent<SpawnGate>().SetEnable(true);
    }

    public void SetStartNum(string name,int num)
    {
        ResetGate();
        if(name.Equals("and"))
        {
            andNum = num;
            and.SetActive(true);
            and.GetComponent<SpawnGate>().SetEnable(true);
        }
        else if(name.Equals("not"))
        {
            notNum = num;
            not.SetActive(true);
            not.GetComponent<SpawnGate>().SetEnable(true);
        }
        else if(name.Equals("or"))
        {
            orNum = num;
            or.SetActive(true);
            or.GetComponent<SpawnGate>().SetEnable(true);
        }
        else if(name.Equals("line"))
        {
            lineNum = num;
            line.SetActive(true);
            line.GetComponent<SpawnGate>().SetEnable(true);
        }
        SetText();
    }

    private void SetText()
    {
        and.transform.Find("number").GetComponent<TMP_Text>().text = andNum.ToString();
        not.transform.Find("number").GetComponent<TMP_Text>().text = notNum.ToString();
        or.transform.Find("number").GetComponent<TMP_Text>().text = orNum.ToString();
        line.transform.Find("number").GetComponent<TMP_Text>().text = lineNum.ToString();
    }

    private void ResetGate()
    {
        and.SetActive(false);
        or.SetActive(false);
        not.SetActive(false);
        line.SetActive(false);
    }
}
