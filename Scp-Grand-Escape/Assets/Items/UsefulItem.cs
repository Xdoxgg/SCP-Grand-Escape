using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class UsefulItem : MonoBehaviour, IInteracteble
{
    [SerializeField] private PlayerInventary _playerInventary;

    [SerializeField] protected GameObject _object;

    [SerializeField] private string _name;

    [SerializeField] private bool _inInventary;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Rigidbody _rigidbody;
    private int _lavel;
    private int _maxLavel;
    private Vector3 _defaultScale;

    public Vector3 DefaultScale
    {
        get { return _defaultScale; }
    }

    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
        set { _rigidbody = value; }
    }

    public int Lavel
    {
        get { return _lavel; }
        set { _lavel = value; }
    }

    public int MaxLavel
    {
        get { return _maxLavel; }
    }

    public virtual void UpdateLavel()
    {
        if (++_lavel <= _maxLavel)
        {
            _lavel++;
        }
        else
        {
            _lavel = _maxLavel;
        }
    }

    public bool InInventary
    {
        get { return this._inInventary; }
        set { this._inInventary = value; }
    }

    public bool IsInventereble()
    {
        return true;
    }

    public UsefulItem()
    {
        _inInventary = false;
    }

    void Start()
    {
        _defaultScale = transform.localScale;
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


    public virtual void Interact()
    {
        _object.SetActive(false);
        _inInventary = true;
        _playerInventary.AddItem(this);
        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        _object.transform.parent = _playerObject.transform;
        _object.transform.rotation = _playerObject.transform.rotation;
        _object.transform.position = _playerObject.transform.position;
    }

    public string GetDesciption()
    {
        return "take " + _name;
    }
}