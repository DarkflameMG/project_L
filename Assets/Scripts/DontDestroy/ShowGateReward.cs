using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGateReward : MonoBehaviour
{
    [SerializeField]private GameObject gateRewardUI;

    public void ShowUI()
    {
        StartCoroutine(ShowGateUI());
    }

    private IEnumerator ShowGateUI()
    {
        gateRewardUI.SetActive(true);
        yield return new WaitForSeconds(2);
        gateRewardUI.SetActive(false);
    }
}
