using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
	public UnityEvent<float> OnLifeChange = new UnityEvent<float>();
	public UnityEvent OnDie = new UnityEvent();

	[SerializeField] private float _maxHP = 100f;
	private float _currentHP;

	private void Start()
	{
		_currentHP = _maxHP;
	}

	public void TakeDamage(float damage)
	{
		_currentHP -= damage;
		OnLifeChange.Invoke(_currentHP/_maxHP);

		if (_currentHP <= 0)
			OnDie.Invoke();
	}
}
