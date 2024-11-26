using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerInventary : MonoBehaviour
{
    [SerializeField] private UsefulItem[] _items;
    [SerializeField] private GameObject _dropPosition;
    [SerializeField] private UI _ui;
    [SerializeField] private GameObject _globalObject;
    private bool _freePlace;


    public void AddItem(UsefulItem item)
    {
        int items = 0;
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                break;
            }
            else
            {
                items++;
            }

        }
    
        _items[items] = item;
        _ui.RenameButtons();
    }

    public void RemoveItem(int index)
    {
        var item = _items[index];
        _items[index] = null;
        _ui.RenameButtons();
        item.transform.localScale = item.DefaultScale;
       
        item.transform.parent = _globalObject.transform;
        item.transform.rotation = _dropPosition.transform.rotation;
        item.transform.position = _dropPosition.transform.position;
        item.SetActive(true);
        item.InInventary = false;
        item.Rigidbody.useGravity = true;
        item.Rigidbody.freezeRotation = false;
        item.Rigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.None;
    
    }

    public PlayerInventary()
    {
        _items = new UsefulItem[4];
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = null;
        }
    }

    public UsefulItem[] Items
    {
        get => _items;
        set => _items = value;
    }
}