using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController _door;
    [SerializeField] private bool _ready = false;
    
    public bool Ready => _ready;
    
    void Update()
    {
        if (_door.DoorOpen)
        {
            _door.Locked = true;
            _ready = true;
        }
    }
    
}