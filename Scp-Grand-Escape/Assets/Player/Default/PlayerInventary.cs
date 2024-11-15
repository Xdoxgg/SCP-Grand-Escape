using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerInventary : MonoBehaviour
{
    [SerializeField] private UsefulItem[] _items;

    [SerializeField] private UI _ui;
    private bool _freePlace;


    public void AddItem(UsefulItem item)
    {
        int items = 0;
        for (int i = 0; i < _items.Length; i++)
        {
            items += (_items[i] == null) ? 0 : 1;
        }
    
        _items[items] = item;
        _ui.RenameButtons();
    }

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