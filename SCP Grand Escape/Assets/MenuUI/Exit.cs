using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
	public void ExitProgramm()
	{
		Debug.Log("Exit program");
		Application.Quit();
	}
}
