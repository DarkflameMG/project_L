using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRewardSys : MonoBehaviour
{
    [SerializeField]private GameObject rewardUI;

    public void ShowReward()
    {
        StartCoroutine(ShowAndHide());
    }
    
    private IEnumerator ShowAndHide()
    {
        yield return new WaitForSeconds(0.15f);
        rewardUI.SetActive(true);
        yield return new WaitForSeconds(3);
        rewardUI.SetActive(false);
        Destroy(rewardUI.transform.Find("rewardSpawnPoint").GetChild(0).gameObject);
    }
}
