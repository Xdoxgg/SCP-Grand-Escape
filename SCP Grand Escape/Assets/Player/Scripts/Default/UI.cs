using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;
using TMPro;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text[] _itemButtonsTexts = new Text[4];
    [SerializeField] private GameObject _button;
    [SerializeField] private bool _menuOpen;
    [SerializeField] private bool _inventoryOpen;
    private System.Timers.Timer _timer;
    private bool _ready;
    [SerializeField] private PlayerInventary _playerInventary;
    [SerializeField] private int _selectedItem;


    private void Start()
    {
        _selectedItem = 0;
        _menuOpen = false;
        _timer = new System.Timers.Timer();
        _timer.Interval = 300;
        _timer.Elapsed += MenuColDown;
        _ready = true;
        _inventoryOpen = false;
        for (int i = 0; i < 2; i++)
        {
            SetText(_itemButtonsTexts[i], _playerInventary.Items[i].Name);
        }
       
        
    }

    private void MenuColDown(object sender, ElapsedEventArgs e)
    {
        _ready = true;
    }


    private static void SetText(Text button, string text)
    {
        button.GetComponentInChildren<Text>().text = text ?? "nothing";
    }

    public void SetSelectedItem(int item)
    {
        if (_selectedItem == item)
        {
            _selectedItem = 0;
        }
        else
        {
            _selectedItem = item;
        }
        _ready = false;
        UnityEngine.Cursor.lockState = !_inventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
        UnityEngine.Cursor.visible = !_inventoryOpen;
        _panel.SetActive(!_inventoryOpen);
        _inventoryOpen = !_inventoryOpen;
        _timer.Start();
        for (int i = 0; i < 2; i++)
        {
            _playerInventary.Items[i].SetActive(false);
        }

        if (_selectedItem != 0)
        {
            _playerInventary.Items[_selectedItem - 1].SetActive(true);
        }
    }




    private void Update()
    {
        if (Input.GetKey(KeyCode.Backspace) && _ready && !_inventoryOpen)
        {
            _ready = false;
            UnityEngine.Cursor.lockState = !_menuOpen ? CursorLockMode.None : CursorLockMode.Locked;
            UnityEngine.Cursor.visible = !_menuOpen;
            _button.SetActive(!_menuOpen);
            _menuOpen = !_menuOpen;
            _timer.Start();
        }

        if (Input.GetKeyDown(KeyCode.I) && _ready && !_menuOpen)
        {
            _ready = false;
            UnityEngine.Cursor.lockState = !_inventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
            UnityEngine.Cursor.visible = !_inventoryOpen;
            _panel.SetActive(!_inventoryOpen);
            _inventoryOpen = !_inventoryOpen;
            _timer.Start();
        }

        switch (_selectedItem)
        {
            case 1:
            {
                if (Input.GetKey(KeyCode.F) && _ready)
                {
                    ((FlashlightItem)_playerInventary.Items[0]).ToggleFlashlight();
                    _ready = false;
                    _timer.Start();
                }
                break;
            }
            case 2:
            {
                if (Input.GetKey(KeyCode.F) && _ready)
                {
                    ((Laptop)_playerInventary.Items[1]).SwapPage();
                    _ready = false;
                    _timer.Start();
                }
                break;
            }
        }
       
    }
}