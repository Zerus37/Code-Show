using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private Toggle _recoilCheckBox;

	private void Start()
	{
		_recoilCheckBox.isOn = PlayerPrefs.GetInt("recoilOn", 1) == 1;
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
