using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;
    [SerializeField]public TextMeshProUGUI gateName;
    [SerializeField]public TextMeshProUGUI description;
    [SerializeField]public Canvas canvas;
    [SerializeField]public Canvas canvas;

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
        // Debug.Log(canvas.scaleFactor);
        // transform.localPosition = Input.mousePosition/canvas.scaleFactor + new Vector3(-1250f,-830f,0);
        // transform.localPosition = transform.localPosition + new Vector3(-1250f,-830f,0);
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
