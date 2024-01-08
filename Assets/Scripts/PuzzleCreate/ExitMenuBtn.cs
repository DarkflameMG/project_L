using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuBtn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private MenuBtn menuOp;
    [SerializeField]private GameObject exitSystem;
    private Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BtnClick);
    }

    private void BtnClick()
    {
        if(menuOp == MenuBtn.lobby)
        {
            exitSystem.GetComponent<ExitSystem>().ToLobby();
        }
        else if(menuOp == MenuBtn.none)
        {
            exitSystem.GetComponent<ExitSystem>().CancelMenu();
        }
        else if(menuOp == MenuBtn.map)
        {
            exitSystem.GetComponent<ExitSystem>().ToMap();
        }
        else if(menuOp == MenuBtn.puzzle)
        {
            exitSystem.GetComponent<ExitSystem>().ToPuzzle();
        }
    }
}
