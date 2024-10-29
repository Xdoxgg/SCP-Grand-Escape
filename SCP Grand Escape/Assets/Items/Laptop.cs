using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Laptop : UsefulItem
{
    [SerializeField] private TextMeshPro[] _pages;
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

        _title.SetText(_pages[_activePage].text);
        
    }
}