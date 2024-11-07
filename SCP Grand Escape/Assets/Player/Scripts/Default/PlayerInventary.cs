using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerInventary: MonoBehaviour
{
    [SerializeField]
    private UsefulItem[] _items;

    public void AddItem(UsefulItem item)
    {
        _items.Append(item);
    }
    
    public PlayerInventary()
    {
        
    }
    
    public UsefulItem[] Items
    {
        get => _items;
        set => _items = value;
    }

}