using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KeySO : ScriptableObject
{
    public List<String> keys;
    public List<Color32> color;
    public int currentIndex;
}
