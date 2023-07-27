using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _player;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        _player.Move(direction);
        SendMove();
    }

    private void SendMove()
	{
		_player.GetMoveInfo(out Vector3 position);
		
		Dictionary<string, object> data = new Dictionary<string, object>()
		{
			{"x", position.x},
			{"y", position.z}
		};
		MultiplayerManager.Instance.SendMessage("move", data);
	}
}
