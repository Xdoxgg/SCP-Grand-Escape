using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnter : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _position;
    [SerializeField] private UsefulItem _usefulItem;
    [SerializeField] private UI _playerUI;
    private bool _seted = false;

    private void Update()
    {
        if (_usefulItem != null)
        {
            if (_usefulItem.InInventary == true)
            {
                _usefulItem = null;
                _seted = false;
            }
        }
    }

    public UsefulItem UsefulItem
    {
        get { return _usefulItem; }
        set { _usefulItem = value; }
    }

    public bool Seted
    {
        set { _seted = value; }
    }
    
    public void Interact()
    {
        if (_playerUI.SelectedItem != 0)
        {
            _usefulItem = _playerUI.PlayerInventary.Items[_playerUI.SelectedItem - 1];
           
        }
        if (_usefulItem != null && !_seted)
        {
            _playerUI.PlayerInventary.RemoveItem(_playerUI.SelectedItem-1);

            _usefulItem.transform.parent = _position.transform;
            _usefulItem.transform.rotation = _position.transform.rotation;
            _usefulItem.transform.position = _position.transform.position;
            _seted = true;
        }
    }



    public string GetDesciption()
    {
        return "Place item for update";
    }

    public bool IsInventereble()
    {
        return false;
    }
}