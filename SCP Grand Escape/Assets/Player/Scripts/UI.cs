using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

	[SerializeField]
	private GameObject _button;
	private bool _menuOpen;
	
	private void Start()
	{
		_menuOpen = false;

	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Backspace))
		{
            _menuOpen=!_menuOpen;
        }
		if (_menuOpen)
		{
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            _button.SetActive(_menuOpen);
        }
	}
}
