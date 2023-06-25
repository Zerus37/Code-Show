using UnityEngine;
using UnityEngine.Events;

public class ObjectDeactivator : MonoBehaviour
{
	public static ObjectDeactivator instance;
	[SerializeField] private GameObject[] objects;

	private void Start()
	{
		instance = this;
	}

	public void SetActivePool(bool flag)
	{
		foreach (GameObject oneObject in objects)
		{
			oneObject.SetActive(flag);
		}
	}
}
