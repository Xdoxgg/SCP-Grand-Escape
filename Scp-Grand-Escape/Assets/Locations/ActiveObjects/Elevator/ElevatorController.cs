using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private DoorController _liftDoor;
    [SerializeField] private GameObject _playerObject;

    private enum Mode
    {
        up,
        down
    }

    [SerializeField] private Mode _mode;

    public void Interact()
    {
        if (_liftDoor.DoorOpen == false)
        {
            if (_mode == Mode.up)
            {
                _playerObject.transform.position = new Vector3(_playerObject.transform.position.x,
                    _playerObject.transform.position.y + 40.5f, transform.position.z);
                _mode = Mode.down;
                Debug.Log("Active up");
            }
            else
            {
                _playerObject.transform.position = new Vector3(_playerObject.transform.position.x,
                    _playerObject.transform.position.y - 18.5f, transform.position.z);
                _mode = Mode.up;
                Debug.Log("Active down");
            }
        }
    }

    public string GetDesciption()
    {
        if (!_liftDoor.DoorOpen)
        {
            return "Go " + _mode.ToString();
        }
        else
        {
            return "Firstly close doors";
        }
    }

    public bool IsInventereble()
    {
        return false;
    }
}