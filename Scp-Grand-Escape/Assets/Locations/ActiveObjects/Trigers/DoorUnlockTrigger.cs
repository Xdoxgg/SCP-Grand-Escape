using UnityEngine;

public class DoorUnlockTrigger : MonoBehaviour
{
    [SerializeField] private DoorController _door;
    [SerializeField] private DoorController _doorTrigger;
    
    void Update()
    {
        if (_doorTrigger.DoorOpen)
        {
            _door.Locked = false;
           
        }
    }
    
}