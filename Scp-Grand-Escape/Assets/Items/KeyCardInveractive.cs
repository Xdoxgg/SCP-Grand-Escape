
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class KeyCardInveractive : UsefulItem
{
    [SerializeField] private int _accept;
    public KeyCardInveractive()
    {
        this.Name = "KeyCard";
        
    }

    public int Accept
    {
        get { return _accept; }
    }
}