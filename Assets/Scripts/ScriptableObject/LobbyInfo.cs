using UnityEngine;
[CreateAssetMenu(fileName = "LobbyInfo", menuName = "Persistence")]
public class LobbyInfo : ScriptableObject {
    public Vector3 PlayerLocation = new Vector3(0,0,-7.84f);
    public bool Busy = false;
    public Page currentPage;
    public QuestType questType;
}


