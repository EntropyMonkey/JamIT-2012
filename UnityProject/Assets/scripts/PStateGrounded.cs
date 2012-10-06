using UnityEngine;
using System.Collections;

public class PStateGrounded : FSMState<Player>
{
	public override void Enter(Player player)
	{
		Debug.Log(player.id + " enter grounded.");
	}

	public override void Execute(Player player)
	{
		if (player.input.KeyDown(ChangingInput.KEYS.JUMP))
		{
			player.fsm.ChangeState(player.pStateJump);
		}
	}

	public override void Exit(Player player)
	{
	}
}