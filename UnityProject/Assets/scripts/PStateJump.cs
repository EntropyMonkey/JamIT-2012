using UnityEngine;
using System.Collections;

class PStateJump : FSMState<Player>
{
	float jumpTimer;

	public override void Enter(Player player)
	{
		jumpTimer = 0;
	}

	public override void ExecuteFixed(Player player)
	{
		if (jumpTimer < player.settings.MaxJumpTime &&
			player.input.KeyDown(ChangingInput.KEYS.JUMP))
		{
			player.rigidbody.AddForce(new Vector3(
				player.settings.JumpSpeed.x * Time.deltaTime,
				player.settings.JumpSpeed.y * Time.deltaTime),
				ForceMode.Impulse);
		}
		else
		{
			player.fsm.ChangeState(player.pStateFall);
		}

		jumpTimer += Time.deltaTime;
	}

	public override void Exit(Player player)
	{
		
	}
}