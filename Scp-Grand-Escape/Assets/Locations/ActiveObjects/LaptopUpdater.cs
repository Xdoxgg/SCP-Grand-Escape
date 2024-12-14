using Unity.VisualScripting;
using UnityEngine;

public class LaptopUpdater:MonoBehaviour, IInteracteble
{
    [SerializeField]private string _data = "";
    private bool _used = false;
    [SerializeField] private PlayerInventary _playerInventary;
    public void Interact()
    {
        foreach (var item in _playerInventary.Items)
        {
            if (item is Laptop)
            {
                _used = true;
                ((Laptop)item).AddPage(_data);
            }
        }
    }

    public string GetDesciption()
    {   
        return _used==true?"already updated":"update laptop info";
    }

    public bool IsInventereble()
    {
        return false;
    }
}