using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MissionSystem : MonoBehaviour
{
    [SerializeField]private MissionSO missionSO;
    [SerializeField]private LobbyInfo lobby;
    public void setCurerntMission(MissionInfo data)
    {
        missionSO.missionInfo = data;
    }

    public MissionInfo GetMissionInfo()
    {
        return missionSO.missionInfo;
    }

    private void Update() {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            completeMission();
        }
    }

    private void completeMission()
    {
        lobby.PlayerLocation = new Vector3(0,0,-7.84f);
        SceneManager.LoadScene("Lobby");
    }
}
