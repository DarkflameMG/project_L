using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogChangeSys : MonoBehaviour
{
    [SerializeField]private GameObject floorCatalogUI;
    [SerializeField]private GameObject featureCatalogUI;
    private GameObject currentCatalogUI;
    private void Awake() {
        currentCatalogUI = floorCatalogUI;
    }

    public void ChangeUI(CreateMapCatalog type)
    {
        if(type == CreateMapCatalog.floor)
        {
            currentCatalogUI.SetActive(false);
            floorCatalogUI.SetActive(true);

            currentCatalogUI = floorCatalogUI;
        }
        else if (type == CreateMapCatalog.feature)
        {
            currentCatalogUI.SetActive(false);
            featureCatalogUI.SetActive(true);
            
            currentCatalogUI = featureCatalogUI;
        }
    }
}
