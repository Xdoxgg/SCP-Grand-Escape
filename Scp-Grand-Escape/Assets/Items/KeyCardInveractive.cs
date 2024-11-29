
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class KeyCardInveractive : UsefulItem
{
    [SerializeField] private int _accept;
    [SerializeField] private GameObject[] _keyCards;
    public KeyCardInveractive()
    {
        this.Name = "KeyCard";
        MaxLavel = 3;
    }

    public override void UpdateLavel()
    {
        base.UpdateLavel();
        _accept = Lavel;
        foreach (GameObject keyCard in _keyCards)
        {
            keyCard.SetActive(false);
        }
        _keyCards[_accept-1].SetActive(true);
    }

    public int Accept
    {
        get { return _accept; }
    }
}