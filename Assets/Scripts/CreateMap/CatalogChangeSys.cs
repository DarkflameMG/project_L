using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatalogChangeSys : MonoBehaviour
{
    [SerializeField]private GameObject floorCatalogUI;
    [SerializeField]private GameObject featureCatalogUI;
    [SerializeField]private GameObject mainPuzzleUI;
    [SerializeField]private GameObject puzzleUI;
    [SerializeField]private GameObject mismatchPuzzleUI;
    [SerializeField]private GameObject puzzleBtn;
    [SerializeField]private RoomCatalogSys roomCatalogSys;
    [SerializeField]private TMP_Text puzzleName;
    private GameObject currentCatalogUI;
    private void Awake() {
        currentCatalogUI = floorCatalogUI;
    }

    private void Update() {
        if(roomCatalogSys.GetCurrentSlot() != null)
        {
            puzzleName.text = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetPuzzleName();
            ChoosePuzzleUI();
        }
    }

    public void ChangeUI(CreateMapCatalog type)
    {
        currentCatalogUI.SetActive(false);
        if(type == CreateMapCatalog.floor)
        {
            floorCatalogUI.SetActive(true);
            currentCatalogUI = floorCatalogUI;
        }
        else if (type == CreateMapCatalog.feature)
        {
            featureCatalogUI.SetActive(true);
            currentCatalogUI = featureCatalogUI;
        }
        else if(type == CreateMapCatalog.puzzle)
        {
            mainPuzzleUI.SetActive(true);
            currentCatalogUI = mainPuzzleUI;
            ChoosePuzzleUI();
        }
    }

    private void ChoosePuzzleUI()
    {
        if(roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetFeatureType() == FeatureType.puzzle)
        {
            puzzleUI.SetActive(true);
            mismatchPuzzleUI.SetActive(false);
        }
        else
        {
            puzzleUI.SetActive(false);
            mismatchPuzzleUI.SetActive(true);
        }
    }
}
