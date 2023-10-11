using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuBtn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private bool isConfirm;
    [SerializeField]private GameObject exitSystem;
    private Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BtnClick);
    }

    private void BtnClick()
    {
        if(isConfirm)
        {
            exitSystem.GetComponent<ExitSystem>().ConfirmExit();
        }
        else
        {
            exitSystem.GetComponent<ExitSystem>().CancelExit();
        }
    }
}
