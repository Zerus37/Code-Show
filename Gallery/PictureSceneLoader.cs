using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureSceneLoader : SceneLoader
{
	[SerializeField] private ObjectDeactivator deactivator;
	[SerializeField] private ProgressPopUp popUp;

	private void Start()
	{
		PicImage.progressPopUp = popUp;
	}

	public override void LoadScene(string sceneName)
	{
		asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		asyncOperation.allowSceneActivation = false;
	}

	public override void ActivateScene()
	{
		asyncOperation.allowSceneActivation = true;

		this.gameObject.SetActive(false);
		deactivator.SetActivePool(false);
	}
}
