using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Button startButton;

	void Start()
	{
		startButton = startButton.GetComponent<Button>();
	}

	public void StartPress()
	{
		Application.LoadLevel(1);
	}
}