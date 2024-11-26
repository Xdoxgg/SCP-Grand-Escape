using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Laptop : UsefulItem
{
    [SerializeField] private string[] _pages;
    [SerializeField] private TextMeshPro _title;
    private int _activePage;

    public int ActivePage
    {
        get => _activePage;
        set => _activePage = value;
    }

    public Laptop()
    {
        _activePage = 0;
        
        Name= "Laptop";
    }

    public override void Interact()
    {
        base.Interact();
        _object.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public override void UpdateLavel()
    {
        base.UpdateLavel();
        //add somethink
    }

    private void Start()
    {
        if (_pages.Length > 0)
        {
            _title.SetText(_pages[_activePage]);
        }
        else
        {
            _title.SetText("no data...");
        }
    }

    public void SwapPage()
    {
        if (_activePage + 1 < _pages.Length)
        {
            _activePage++;
        }
        else
        {
            _activePage = 0;
        }

        _title.SetText(_pages[_activePage]);
        
    }
}