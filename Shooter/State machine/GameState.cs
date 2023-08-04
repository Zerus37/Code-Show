using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
	public GameState(Player player, Camera cam, float mouseSensetivity, bool recoilOn)
	{
		_player = player;
		_cam = cam;
		_mouseSensetivity = mouseSensetivity;
		_recoilOn = recoilOn;
	}

	private Player _player;
	private Camera _cam;
	private float _mouseSensetivity;
	private bool _recoilOn;

	public override void Enter()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public override void Exit()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public override void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			_player.Jump();

		_player.Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));

		_player.RotateX(-Input.GetAxis("Mouse Y") * _mouseSensetivity);
		_player.RotateY(Input.GetAxis("Mouse X") * _mouseSensetivity);

		if (Input.GetMouseButton(0))
		{
			if (_player.Fire() && _recoilOn)
				SimulateRecoil();
		}
	}

	public void ChangeRecoil()
	{
		_recoilOn = PlayerPrefs.GetInt("recoilOn", 1) == 1;
	}

	private void SimulateRecoil()
	{
		_player.RotateX(-Random.Range(1f, 6f));
		_player.RotateY(-Random.Range(-2f, 2f));
	}
}
