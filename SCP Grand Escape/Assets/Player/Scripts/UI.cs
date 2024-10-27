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
    }

    private void MenuColDown(object sender, ElapsedEventArgs e)
    {
        _ready = true;
    }


    private static void SetText(Text button, string text)
    {
        if (text != null)
        {
            button.GetComponentInChildren<Text>().text = text;
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "nothing";
        }
    }

    public void SetSelectedItem(int item)
    {
        if (_selectedItem == _selectedItem)
        {
            _selectedItem = 0;
        }
        else
        {
            _selectedItem = item;
        }

        for (int i = 0; i < _playerInventary.Items.Length; i++)
        {
            _playerInventary.Items[i].SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Tab) && _ready && !_menuOpen)
        {
            _ready = false;
            UnityEngine.Cursor.lockState = !_inventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
            UnityEngine.Cursor.visible = !_inventoryOpen;
            _panel.SetActive(!_inventoryOpen);
            _inventoryOpen = !_inventoryOpen;
            _timer.Start();
            for (int i = 0; i < _itemButtonsTexts.Length; i++)
            {
                SetText(_itemButtonsTexts[i], _playerInventary.Items[i].Name);
            }
        }

        switch (_selectedItem)
        {
            case 1:{
                _playerInventary.Items[0].SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    ((FlashlightItem)_playerInventary.Items[0]).ToggleFlashlight();
                }
                break;
            }
        }
    }
}