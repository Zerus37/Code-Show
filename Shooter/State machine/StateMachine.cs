using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	public State CurrentState { get; set; }
	public void Iitialize(State startState)
	{
		CurrentState = startState;
		CurrentState.Enter();
	}

	public void ChangeState(State newState)
	{
		CurrentState.Exit();
		CurrentState = newState;
		CurrentState.Enter();
	}
}
