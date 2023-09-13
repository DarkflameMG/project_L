using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GateSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string gateName;
    public string description;
}
