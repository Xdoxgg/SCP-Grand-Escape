using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UsefulItem : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public void SetActive(bool value)
    {
        _object.SetActive(value);
    }
    
    public void TakeItem()
    {
    }
}