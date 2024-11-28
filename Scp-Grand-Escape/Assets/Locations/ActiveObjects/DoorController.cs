using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private bool _doorOpen;

    [SerializeField] Animator _doorAnimation1;
    [SerializeField] Animator _doorAnimation2;
    [SerializeField] private int _acceptLevel;
    [SerializeField] private PlayerInventary _playerInventary;
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
            if (_acceptLevel == 0)
            {
                _doorOpen = !_doorOpen;
                if (_doorOpen)
                {
                    _doorAnimation1.SetBool("IsOpen", true);
                    _doorAnimation2.SetBool("IsOpen", true);
                }
                else
                {
                    _doorAnimation1.SetBool("IsOpen", false);
                    _doorAnimation2.SetBool("IsOpen", false);
                }
            }
            else
            {
                foreach (var item in _playerInventary.Items)
                {
                    if (item != null)
                    {
                        if (item.Name == "KeyCard")
                        {
                            if (((KeyCardInveractive)item).Accept >= _acceptLevel && item.isActiveAndEnabled)
                            {
                                _doorOpen = !_doorOpen;
                                if (_doorOpen)
                                {
                                    _doorAnimation1.SetBool("IsOpen", true);
                                    _doorAnimation2.SetBool("IsOpen", true);
                                }
                                else
                                {
                                    _doorAnimation1.SetBool("IsOpen", false);
                                    _doorAnimation2.SetBool("IsOpen", false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public string GetDesciption()
    {
        if (!_locked)
        {
            if (_acceptLevel == 0)
            {
                return _doorOpen ? "Close" : "Open";
            }
            else
            {
                return "for " + (_doorOpen ? "close" : "open") + " door you need " + _acceptLevel.ToString() +
                       "  key card level";
            }
        }
        else
        {
            return "Door locked";
        }
    }
    
}