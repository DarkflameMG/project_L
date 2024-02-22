using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LogicGateSO : ScriptableObject
{
    public int and;
    public int or;
    public int not;
    public int xor;
    public int nand;
    public int nor;
    public int xnor;
    public int highVolt;
    public int lowVolt;
    public int line; 
}
