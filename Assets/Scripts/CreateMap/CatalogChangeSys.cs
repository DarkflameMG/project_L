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
    [SerializeField]private GameObject puzzleV1;
    [SerializeField]private GameObject truthPuzzle;
    [SerializeField]private GameObject mismatchPuzzleUI;
    [SerializeField]private GameObject puzzleBtn;
    [SerializeField]private GameObject configUI;
    [SerializeField]private GameObject listOfConfigUI;
    [SerializeField]private GameObject config404UI;
    [SerializeField]private RoomCatalogSys roomCatalogSys;
    [SerializeField]private TMP_Text puzzleName;
    [SerializeField]private TMP_Text puzzleHeader;
    private GameObject currentCatalogUI;
    private void Awake() {
        currentCatalogUI = floorCatalogUI;
    }

    private void Update() {
        if(roomCatalogSys.GetCurrentSlot() != null)
        {
            puzzleName.text = roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetPuzzleName();
            ChoosePuzzleUI();
            CheckConfigUI();
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
        else if(type == CreateMapCatalog.cofig)
        {
            configUI.SetActive(true);
            currentCatalogUI = configUI;
            CheckConfigUI();
        }
    }

    private void ChoosePuzzleUI()
    {
        if(roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetFeatureType() == FeatureType.puzzle)
        {
            puzzleUI.SetActive(true);
            mismatchPuzzleUI.SetActive(false);
            puzzleV1.SetActive(true);
            truthPuzzle.SetActive(false);
            puzzleHeader.text = "current puzzle";
        }
        else if(roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetFeatureType() == FeatureType.exit)
        {
            puzzleUI.SetActive(true);
            mismatchPuzzleUI.SetActive(false);
            puzzleV1.SetActive(false);
            truthPuzzle.SetActive(true);
            puzzleHeader.text = "current truth table";
        }
        else
        {
            puzzleUI.SetActive(false);
            mismatchPuzzleUI.SetActive(true);
        }
    }

    private void CheckConfigUI()
    {
         if(roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetFeatureType() == FeatureType.puzzle)
        {
            listOfConfigUI.SetActive(true);
            config404UI.SetActive(false);
        }
        else if(roomCatalogSys.GetCurrentSlot().GetComponent<RoomSlot>().GetFeatureType() == FeatureType.exit)
        {
            listOfConfigUI.SetActive(true);
            config404UI.SetActive(false);
        }
        else
        {
            listOfConfigUI.SetActive(false);
            config404UI.SetActive(true);
        }
    }
}
