using UnityEngine;
using System.Collections;

class PStateFall : FSMState<Player>
{
	public override void Enter(Player player)
	{
		Debug.Log("(" + player.id + ") fall: enter");		
	}

	public override void Exit(Player player)
	{

	}
}