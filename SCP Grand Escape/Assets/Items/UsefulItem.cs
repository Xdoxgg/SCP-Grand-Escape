using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsefulItem : MonoBehaviour, IInteracteble
{
    [SerializeField] private PlayerInventary _playerInventary;

    [SerializeField] private GameObject _object;

    private string _name;

    [SerializeField] private bool _inInventary;
    [SerializeField] private GameObject _playerObject;

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
        _object.transform.parent = _playerObject.transform;
        _object.transform.rotation = _playerObject.transform.rotation;
        _object.transform.position = _playerObject.transform.position+new Vector3(0.6f,0.2f,-1f);
    }

    public string GetDesciption()
    {
        return "take " + _name;
    }
}