using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _door1;
    [SerializeField] private GameObject _door2;
    [SerializeField] private bool _doorOpen;
    private bool _startOpen;
    
    public bool IsInventereble()
    {
        return false;
    }

    public DoorController()
    {
        _doorOpen = false;
    }

    public void Interact()
    {
        // while (_door1.transform.position.x<-2.97f+5f && _door2.transform.position.x<-7.96f-5f)
        // {
        //     _door1.transform.position += new Vector3(0.5f,0f,0f);
        //     _door2.transform.position -= new Vector3(0.5f,0f,0f);
        // }
        //
        // // _door1.SetActive(_doorOpen);
        // // _door2.SetActive(_doorOpen);
        // _doorOpen = !_doorOpen;
        _startOpen = !_startOpen;
    }

    public void Update()
    {
        if (!_doorOpen && _startOpen)
        {
            //hello
        }
        
        
    }

    public string GetDesciption()
    {
        return _doorOpen ? "Close" : "Open";
    }
}