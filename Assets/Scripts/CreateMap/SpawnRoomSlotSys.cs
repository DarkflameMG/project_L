using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoomSlotSys : MonoBehaviour
{
    [SerializeField]private GameObject main;
    [SerializeField]private GameObject initGrid;
    [SerializeField]private GameObject customMap;
    [SerializeField]private Transform slotPrefab;
    [SerializeField]private Transform horizontalPrefab;
    [SerializeField]private Transform slotSpawnPoint;
    private int width,hight;
    public void StartCreateMap(int x,int y)
    {
        width = x;
        hight = y;
        main.SetActive(false);
        initGrid.SetActive(false);
        customMap.SetActive(true);

        GenerateSlot();
        SetRoomAround();
    }

    private void GenerateSlot()
    {
        for(int j=0;j<hight;j++)
        {
            Transform horizontal = Instantiate(horizontalPrefab,slotSpawnPoint);
            for(int i=0;i<width;i++)
            {
                Instantiate(slotPrefab,horizontal).GetComponent<RoomSlot>().SetXY(i,j);
            }
        }
    }

    private void SetRoomAround()
    {
        for(int j=0;j<hight;j++)
        {
            Transform horizontal = slotSpawnPoint.GetChild(j);
            for(int i=0;i<width;i++)
            {
                horizontal.GetChild(i).GetComponent<RoomSlot>().SetRoomAround();
            }
        }
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHight()
    {
        return hight;
    }
}
