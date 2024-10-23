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
	[SerializeField]
	private bool _menuOpen;
	private System.Timers.Timer _timer;
	private bool _ready;
  

    private void Start()
	{
		_menuOpen = false;
		_timer = new System.Timers.Timer();
		_timer.Interval = 300;
        _timer.Elapsed += MenuColDown;
		_ready = true;

    }

    private void MenuColDown(object sender, ElapsedEventArgs e)
    {
		_ready = true;
    }

    private void Update()
	{
		if (Input.GetKey(KeyCode.Backspace) && _ready)
		{
			_ready = false;
			UnityEngine.Cursor.lockState = !_menuOpen ? CursorLockMode.None : CursorLockMode.Locked;
			UnityEngine.Cursor.visible = !_menuOpen;
			_button.SetActive(!_menuOpen);
			_menuOpen = !_menuOpen;
			_timer.Start();
		}
		
		
	}
}
