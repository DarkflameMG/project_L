using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
   public void SaveProgression()
   {
        this.gameObject.SetActive(true);
        Debug.Log("save");
        StartCoroutine(Timer());
   }

   private IEnumerator Timer()
   {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
   }
}
