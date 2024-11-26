
using UnityEngine;
using UnityEngine.UIElements;

public class SCP914 : MonoBehaviour, IInteracteble
{
    

    [SerializeField] private GameObject _object;
    [SerializeField] private PlatformEnter _platformEnter;
    [SerializeField] private PlatformEnd _platformEnd;
    [SerializeField] private UsefulItem _usefulItem;
    
    public void Interact()
    {
        _usefulItem = _platformEnter.UsefulItem;
        _usefulItem.UpdateLavel();
       
        _platformEnd.UsefulItem=_usefulItem;
        
    }

    public string GetDesciption()
    {
        return "Active";
    }

    public bool IsInventereble()
    {
        return false;
    }

}
