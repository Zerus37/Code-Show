using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressPopUp : MonoBehaviour
{
	[SerializeField] private Slider bar;
	[SerializeField] private TextMeshProUGUI text;

	[SerializeField] private float minSeconds = 2f;
	[SerializeField] private float maxSeconds = 3f;

	[SerializeField] private string activatedSceneName;

	[SerializeField] private SceneLoader sceneLoader;

	[SerializeField] private bool firstIteration = true;

	private float currentValue = 0f;

	private void Start()
	{
		if(firstIteration)
			firstIteration = false;
	}

	private void OnEnable()
	{
		if (firstIteration)
			return;

		sceneLoader.LoadScene(activatedSceneName);
		currentValue = 0f;
	}

	private void Update()
	{
		if (currentValue >= 1f)
		{
			sceneLoader.ActivateScene();
			this.gameObject.SetActive(false);
			return;
		}

		currentValue += Time.deltaTime / Random.Range(minSeconds, maxSeconds);
		bar.value = currentValue;

		int percent = (int) (currentValue * 100f);

		text.text = percent.ToString()+"%";
	}
}
