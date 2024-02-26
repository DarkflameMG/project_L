using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMap : MonoBehaviour
{
    [SerializeField]private GameObject map;
    // private bool toggle = false;

    private void Awake() {
        DontDestroyOnLoad(map);
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        // if(Input.GetKeyDown(KeyCode.B))
        // {
        //     map.SetActive(toggle);
        //     toggle = !toggle;
        //     Destroy(map);
        // }
    }

    public void MapToFight()
    {
        map.SetActive(false);
    }

    public void FightToMap()
    {
        map.SetActive(true);
    }

    public void MapToLobby()
    {
        Destroy(map);
    }
}