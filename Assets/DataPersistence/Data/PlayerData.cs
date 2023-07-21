using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int _slotNumber;

    [SerializeField]
    private string _name;

    [SerializeField]
    private Vector3 _position;

    [SerializeField]
    private Inventory _inventory;


    public void reSet()
    {
        _slotNumber = 0;
        _name = null;
        _position = Vector3.zero;
        _inventory = new Inventory();
        _inventory.goldCoins = 0;
    }
    public int SlotNumber
    {
        get { return _slotNumber; }
        set { _slotNumber = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Vector3 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public Inventory Inventorys
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

}
