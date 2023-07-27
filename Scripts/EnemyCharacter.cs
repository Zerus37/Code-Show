using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
	private Vector3 _targetPosition;

	public void SetTagetPosition(Vector3 position)
	{
		_targetPosition = position;
	}

	private void Awake()
	{
		_targetPosition = transform.position; //Иначе, без ввода, модель врага со старта стремится в нулевую точку карты
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, _targetPosition, 0.25f); // 0.25f в бинарном виде более "круглое", что может сэкономить пару фреймов
	}
}
