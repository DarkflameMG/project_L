using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnGate : MonoBehaviour
{
    [SerializeField]private Sprite img;
    [SerializeField]private Transform prefab;
    [SerializeField]private Transform spawnPoint;

    // private bool start = false;
    private void Start() {
        GetComponent<Image>().sprite = img;
        // if(!start)
        // {
        //     click();
        //     start = true;
        // }
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(click);
    }

    private void click()
    {
        Debug.Log("click");
        Transform notTranform = Instantiate(prefab,spawnPoint);
        notTranform.localPosition = Vector3.zero;
    }
}
