using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerData : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float _hp;

    [SerializeField]
    private Vector3 _position;

    [SerializeField]
    private List<string> _equipment = new List<string>();

    [SerializeField]
    private List<string> _checkpoint = new List<string>();

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public string getEquipment(int index)
    {
        return _equipment[index];
    }

    public void setEquipment(int index,string name)
    {
        _equipment[index] = name;
    }

    public string getCheckpoint(int index)
    {
        return _checkpoint[index];
    }

    public void setCheckpoint(int index, string name)
    {
        _checkpoint[index] = name;
    }
}
