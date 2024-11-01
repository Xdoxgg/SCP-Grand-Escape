using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventary: MonoBehaviour
{
    [SerializeField]
    private UsefulItem[] _items;

    public PlayerInventary()
    {
        _items = new UsefulItem[4];
    }
    
    public UsefulItem[] Items
    {
        get => _items;
        set => _items = value;
    }
}