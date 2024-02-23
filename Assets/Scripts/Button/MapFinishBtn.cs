using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapFinishBtn : MonoBehaviour
{
    private Button btn;
    private void Awake() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Completed);
    }

    private void Completed()
    {
        SceneManager.LoadScene("lobby");
    }
}
