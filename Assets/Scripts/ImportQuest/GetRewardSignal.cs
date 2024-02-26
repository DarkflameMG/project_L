using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRewardSignal : MonoBehaviour
{
    private static bool signal = false;

    public static void SetSignal(bool signal)
    {
        GetRewardSignal.signal = signal;
    }

    public static bool GetSignal()
    {
        return signal;
    }
}
