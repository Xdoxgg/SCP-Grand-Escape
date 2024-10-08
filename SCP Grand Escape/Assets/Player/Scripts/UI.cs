using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Timers;

public class UI : MonoBehaviour
{

	[SerializeField]
	private Canvas _canvas;
	private void Start()
	{
		Button Exit = new Button();
		_canvas.AddComponent<Exit>();

	}
	private void Update()
	{

	}
}
