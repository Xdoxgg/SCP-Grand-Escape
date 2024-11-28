using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorUpDown : MonoBehaviour, IInteracteble
{
    [SerializeField] private bool _doorOpen;

    [SerializeField] Animator _doorAnimation;


    [SerializeField] private bool _locked = false;

    public bool DoorOpen => _doorOpen;

    public bool Locked
    {
        get { return _locked; }
        set { _locked = value; }
    }

    public bool IsInventereble()
    {
        return false;
    }


    public void Interact()
    {
        if (!_locked)
        {
            _doorOpen = !_doorOpen;
            if (_doorOpen)
            {
                _doorAnimation.SetBool("IsOpen", true);
            }
            else
            {
                _doorAnimation.SetBool("IsOpen", false);
            }
        }
    }


    public string GetDesciption()
    {
        if (!_locked)
        {
            return _doorOpen ? "Close" : "Open";
        }
        else
        {
            return "Door locked";
        }
    }
}