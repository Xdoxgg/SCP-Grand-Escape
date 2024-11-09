using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private GameObject _door;
    [SerializeField] private bool _doorOpen;
    
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
        _door.SetActive(_doorOpen);
        _doorOpen = !_doorOpen;
    }

    public string GetDesciption()
    {
        return _doorOpen ? "Close" : "Open";
    }
}