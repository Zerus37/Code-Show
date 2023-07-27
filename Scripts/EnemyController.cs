using Colyseus.Schema;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private EnemyCharacter _character;

	internal void OnChange(List<DataChange> changes)
	{
		Vector3 position = _character.transform.position;
		foreach (var dataChange in changes)
		{
			switch (dataChange.Field)
			{
				case "x":
					position.x = (float)dataChange.Value;
					break;
				case "y":
					position.z = (float)dataChange.Value;
					break;
				default:
					Debug.LogWarning("На обрабатывается изменение поля " + dataChange.Field);
					break;
			}
		}

		_character.SetTagetPosition(position);
	}
}
