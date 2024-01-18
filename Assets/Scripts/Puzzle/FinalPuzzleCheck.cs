using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalPuzzleCheck : MonoBehaviour
{
    [SerializeField]private GameObject checkBtn;
    [SerializeField]private GameObject exitBtn;
    [SerializeField]private GameObject StatusUI;
    [SerializeField]private TMP_Text statusText;
    [SerializeField]private CuurentTruthTableSO truthTableSO;
    private TruthTable table;

    private void Awake() {
        table = truthTableSO.table;
    }
}
