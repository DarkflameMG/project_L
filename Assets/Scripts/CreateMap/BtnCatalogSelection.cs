using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCatalogSelection : MonoBehaviour
{
    [SerializeField]private CreateMapCatalog catalog;
    [SerializeField]private CatalogChangeSys catalogChangeSys;
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SwitchTo);
    }

    private void SwitchTo()
    {
        catalogChangeSys.GetComponent<CatalogChangeSys>().ChangeUI(catalog);
    }
}
