
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

    public override void UpdateLavel()
    {
        base.UpdateLavel();
        _accept++;
    }

    public int Accept
    {
        get { return _accept; }
    }
}