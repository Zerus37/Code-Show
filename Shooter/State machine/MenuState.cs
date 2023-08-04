using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{
	public MenuState(GameObject menu)
	{
		_menuPopup = menu;
	}

	private GameObject _menuPopup;

	public override void Enter()
	{
		Time.timeScale = 0f;
		_menuPopup.SetActive(true);
	}

	public override void Exit()
	{
		Time.timeScale = 1f;
		_menuPopup.SetActive(false);
	}
}
