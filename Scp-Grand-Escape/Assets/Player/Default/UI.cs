using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
//using TMPro.EditorUtilities;
//using Unity.VisualScripting;
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
    [SerializeField] private GameObject _buttonExit;
    [SerializeField] private bool _menuOpen;
    [SerializeField] private bool _inventoryOpen;
    [SerializeField] private PlayerInventary _playerInventary;
    [SerializeField] private int _selectedItem;
    [SerializeField] private CameraController _cameraController;
    public int SelectedItem
    {
        get { return _selectedItem; }
        set { _selectedItem = value; }
    }

    public PlayerInventary PlayerInventary
    {
        get { return _playerInventary; }
        
    }

    private void Start()
    {
        _selectedItem = 0;
        _menuOpen = false;
        
        _inventoryOpen = false;
         for (int i = 0; i < _playerInventary.Items.Length; i++)
         {
             SetText(_itemButtonsTexts[i], _playerInventary.Items[i]==null?"none":_playerInventary.Items[i].Name);
         }

    }

    public void RenameButtons()
    {
        for (int i = 0; i < _playerInventary.Items.Length; i++)
        {
            string text=_playerInventary.Items[i]==null?"none":_playerInventary.Items[i].Name;
             
            SetText(_itemButtonsTexts[i], text);
        }
    }

    
    private static void SetText(Text button, string text)
    {
        button.GetComponentInChildren<Text>().text = text ?? "nothing";
    }

    public void SetSelectedItem(int item)
    {

        _selectedItem = _selectedItem == item ? 0 : item;
        UnityEngine.Cursor.lockState = !_inventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
        UnityEngine.Cursor.visible = !_inventoryOpen;
        _panel.SetActive(!_inventoryOpen);
        _inventoryOpen = !_inventoryOpen;

        for (int i =0; i<  _playerInventary.Items.Length; i++)
        {
            if (_playerInventary.Items[i] != null)
            {
                _playerInventary.Items[i].SetActive(false);
            }
        }
        if (_selectedItem != 0 &&_playerInventary.Items[_selectedItem-1] != null)
        {
            _playerInventary.Items[_selectedItem - 1].SetActive(true);
        }
    }


    

    private void Update()
    {
        if (_inventoryOpen || _menuOpen)
        {
            _cameraController.mouseSensetive = 0f;
        }
        else
        {
            _cameraController.mouseSensetive = 2f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !_inventoryOpen)
        {
            
            UnityEngine.Cursor.lockState = !_menuOpen ? CursorLockMode.None : CursorLockMode.Locked;
            UnityEngine.Cursor.visible = !_menuOpen;
            _buttonExit.SetActive(!_menuOpen);
            _menuOpen = !_menuOpen;
           
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !_menuOpen)
        {
            UnityEngine.Cursor.lockState = !_inventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
            UnityEngine.Cursor.visible = !_inventoryOpen;
            _panel.SetActive(!_inventoryOpen);
            _inventoryOpen = !_inventoryOpen; ;
        }

        if (_selectedItem != 0 && _playerInventary.Items[_selectedItem - 1] != null)
        {
            switch (_playerInventary.Items[_selectedItem-1].Name)
            {
                case "Flashlight":
                {

                    if (Input.GetKeyDown(KeyCode.F))
                    {

                        ((FlashlightItem)_playerInventary.Items[_selectedItem-1]).ToggleFlashlight();

                    }

                    break;
                }
                case "Laptop":
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ((Laptop)_playerInventary.Items[_selectedItem-1]).SwapPage();

                    }

                    break;
                }
            }
        }
    }
}