using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    protected AsyncOperation asyncOperation;

	public virtual void LoadScene(string sceneName)
	{
		asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		asyncOperation.allowSceneActivation = false;
	}

	public virtual void ActivateScene()
	{
		asyncOperation.allowSceneActivation = true;
    }
}
