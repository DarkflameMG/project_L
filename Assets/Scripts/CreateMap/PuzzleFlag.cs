using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleFlag : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    private Color32 red = new(255,0,0,255);
    private Color32 green = new(0,255,0,255);
    private RoomSlot roomSlot;
    private void Update() {
        if(roomSlot != null)
        {
            if(roomSlot.GetPuzzleName().Equals("none"))
            {
                text.text = "None";
                text.color = red;
            }
            else
            {
                text.text = "Fill";
                text.color = green;
            }
        }
    }

    public void SetRoomSlot(RoomSlot roomSlot)
    {
        this.roomSlot = roomSlot;
    }
}
