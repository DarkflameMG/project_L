using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    private int current_x;
    private int current_y;

    public void updatePos(int x,int y)
    {
        current_x += x;
        current_y += y;
    }
}
