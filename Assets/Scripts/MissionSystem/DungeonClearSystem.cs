using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonClearSystem : MonoBehaviour
{
    // [SerializeField]LobbyInfo mapInfo;

    public void MissionClear()
    {
        SceneManager.LoadScene("Lobby");
    }
}
