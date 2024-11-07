using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsefulItem : MonoBehaviour, IInteracteble
{
    [SerializeField]
    private PlayerInventary _playerInventary;
    
    [SerializeField] private GameObject _object;
    private string _name;
    [SerializeField] private bool _inInventary;

    public bool InInventary
    {
        get { return this._inInventary; }
    }

    public bool IsInventereble()
    {
        return true;
    }

    public UsefulItem()
    {
        _inInventary = false;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public void SetActive(bool value)
    {
        _object.SetActive(value);
    }

    public void Interact()
    {
        _object.SetActive(false);
        _inInventary = true;
        _playerInventary.AddItem(this);
    }

    public string GetDesciption()
    {
        return "take " + _name;
    }
}