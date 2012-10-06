using UnityEngine;
using System.Collections;

public class ChangingInput : MonoBehaviour
{
	public enum KEYS { JUMP, ACCELERATE, DECELERATE };

	public bool KeyPressed(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
			return Input.GetKeyDown(KeyCode.W) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKeyDown(KeyCode.D) ? true : false;

		if (key == KEYS.DECELERATE)
			return Input.GetKeyDown(KeyCode.A) ? true : false;

		return false;		
	}

	public bool KeyDown(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
			return Input.GetKey(KeyCode.W) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKey(KeyCode.D) ? true : false;

		if (key == KEYS.DECELERATE)
			return Input.GetKey(KeyCode.A) ? true : false;

		return false;
	}

	public bool KeyReleased(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
			return Input.GetKeyUp(KeyCode.W) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKeyUp(KeyCode.D) ? true : false;

		if (key == KEYS.DECELERATE)
			return Input.GetKeyUp(KeyCode.A) ? true : false;

		return false;
	}
}
