using UnityEngine;
using System.Collections;

class PStateFall : FSMState<Player>
{
	public override void Enter(Player player)
	{
		Debug.Log(player.id + " enter fall.");	
	}

	public override void Exit(Player player)
	{

	}
}