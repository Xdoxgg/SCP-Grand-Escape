using UnityEngine;

public class PlatformEnd : MonoBehaviour, IInteracteble
{
    
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _position;
    [SerializeField] private UsefulItem _usefulItem;
    

    public UsefulItem UsefulItem
    {
        set
        {
            _usefulItem = value;
            
            _usefulItem.transform.parent = _platform.transform;
            _usefulItem.transform.rotation = _position.transform.rotation;
            _usefulItem.transform.position = _position.transform.position;
        }
    }
    
    
    public void Interact()
    {
        ///
    }



    public string GetDesciption()
    {
        return "Take item";
    }

    public bool IsInventereble()
    {
        return false;
    }
}