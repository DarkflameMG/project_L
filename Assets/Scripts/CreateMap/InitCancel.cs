using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitCancel : MonoBehaviour
{
    private Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CancelInit);
    }

    private void CancelInit()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
