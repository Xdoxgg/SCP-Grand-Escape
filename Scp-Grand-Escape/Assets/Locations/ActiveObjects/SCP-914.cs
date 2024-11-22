using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP914 : MonoBehaviour, IInteracteble
{
    
    [SerializeField] private string _mode;
    [SerializeField] private GameObject _updatedObject;
    public void Interact()
    {
        switch (_mode)
        {
            case "mode1":
            {
                
                
                break;
            }
        }
    }

    public string GetDesciption()
    {
        return "Active SCP-914";
    }

    public bool IsInventereble()
    {
        return false;
    }
}
