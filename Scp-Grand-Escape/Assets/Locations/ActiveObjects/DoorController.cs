using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour, IInteracteble
 {
     
    [SerializeField] private bool _doorOpen;

    [SerializeField] Animator _doorAnimation1;
    [SerializeField] Animator _doorAnimation2;
    public bool IsInventereble()
    {
        return false;
    }
    
 

    public void Interact()
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
    

    public string GetDesciption()
    {
        return _doorOpen ? "Close" : "Open";
    }
}