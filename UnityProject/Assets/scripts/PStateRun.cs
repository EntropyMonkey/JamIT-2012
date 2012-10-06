using UnityEngine;
using System.Collections;

class PStateRun : FSMState<Player>
{
	public override void Enter(Player player)
	{
		Debug.Log("(" + player.id + ") run: enter");
	}

	public override void Execute(Player player)
	{
		if (player.input.KeyDown(ChangingInput.KEYS.ACCELERATE))
		{
			player.rigidbody.AddForce(
				new Vector3(
					player.settings.MaxRunSpeed * Time.deltaTime, 0, 0), 
					ForceMode.Impulse);

			if (player.rigidbody.velocity.x > player.settings.MaxRunSpeed)
			{
				Vector3 newVel = player.rigidbody.velocity;
				newVel.x = player.settings.MaxRunSpeed;
				player.rigidbody.velocity = newVel;
			}
		}
		else if (player.input.KeyDown(ChangingInput.KEYS.DECELERATE))
		{
			player.rigidbody.AddForce(
				new Vector3(
					-player.settings.DecelerateSpeed * Time.deltaTime, 0, 0),
					ForceMode.Impulse);

			if (player.rigidbody.velocity.x < 0.0f)
			{
				Vector3 newVel = player.rigidbody.velocity;
				newVel.x = 0;
				player.rigidbody.velocity = newVel;
			}
		}
		else
		{
			player.rigidbody.velocity = Vector3.Lerp(
				player.rigidbody.velocity,
				new Vector3(player.settings.StandardRunSpeed, 0, 0),
				player.settings.ToStandardSpeedSmoothing * Time.deltaTime);
		}

		if (player.input.KeyDown(ChangingInput.KEYS.JUMP))
		{
			player.fsm.ChangeState(player.pStateJump);
		}
	}

	public override void Exit(Player player)
	{

	}
}