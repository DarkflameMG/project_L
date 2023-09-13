using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    [SerializeField]public TextMeshProUGUI gateName;
    [SerializeField]public TextMeshProUGUI description;

    private void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Input.mousePosition + new Vector3(-950f,-550f,0);
    }

    public void SetAndShow(string name,string desc)
    {
        gameObject.SetActive(true);
        gateName.text = name;
        description.text = desc;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        gateName.text = string.Empty;
        description.text = string.Empty;
    }
}
