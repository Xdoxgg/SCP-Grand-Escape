using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _door1;
    [SerializeField] private GameObject _door2;
    [SerializeField] private bool _doorOpen;
    private bool _startOpen;
    private Vector3 _startPosition1;
    private Vector3 _startPosition2;
    private bool _door1Open;
    private bool _door2Open;

    public bool IsInventereble()
    {
        return false;
    }

    void Start()
    {
        _startPosition1 = _door1.transform.position;
        _startPosition2 = _door2.transform.position;
    }

    public DoorController()
    {
        _doorOpen = false;
        _startOpen = false;
        _door1Open = false;
        _door2Open = false;
    }

    public void Interact()
    {
        _startOpen = !_startOpen;
    }

    void Update()
    {
        if (_startOpen && !_doorOpen)
        {
            if (_door1.transform.position.z < _startPosition1.z+1f)
            {
                _door1.transform.position = MoveAtZ(_door1.transform.position, 0.5f);
            }
            else
            {
                _door1Open = true;
            }

            if (_door2.transform.position.z > _startPosition2.z-1f)
            {
                _door2.transform.position = MoveAtZ(_door2.transform.position, -0.5f);
            }
            else
            {
                _door2Open = true;
            }

            if (_door1Open && _door2Open)
            {
                _door1.SetActive(false);
                _door2.SetActive(false);
                _door1Open = false;
                _door2Open = false;
                _startOpen = false;
                _doorOpen = true;
            }
        }

        if (_startOpen && _doorOpen)
        {
            if (_door1.activeSelf == false && _door2.activeSelf == false)
            {
                _door1.SetActive(true);
                _door2.SetActive(true);
            }

            if (_door1.transform.position.z > _startPosition1.z)
            {
                _door1.transform.position = MoveAtZ(_door1.transform.position, -0.5f);
            }
            else
            {
                _door1Open = true;
            }

            if (_door2.transform.position.z < _startPosition2.z)
            {
                _door2.transform.position = MoveAtZ(_door2.transform.position, 0.5f);
            }
            else
            {
                _door2Open = true;
            }

            if (_door1Open && _door2Open)
            {
                _door1.transform.position = _startPosition1;
                _door2.transform.position = _startPosition2;
                _door1Open = false;
                _door2Open = false;
                _startOpen = false;
                _doorOpen = false;
            }
        }
    }


    private Vector3 MoveAtZ(Vector3 position, float on)
    {
        position.z += on * Time.deltaTime;
        return position;
    }

    public string GetDesciption()
    {
        return _doorOpen ? "Close" : "Open";
    }
}