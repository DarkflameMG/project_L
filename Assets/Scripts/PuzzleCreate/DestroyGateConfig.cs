using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyGateConfig : MonoBehaviour
{
    Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DestroyConfig);
    }

    private void DestroyConfig()
    {
        Destroy(transform.parent.gameObject);
    }
}
