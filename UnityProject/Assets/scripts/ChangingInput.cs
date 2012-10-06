using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangingInput : MonoBehaviour
{
	public enum KEYS { JUMP, ACCELERATE, DECELERATE };

    [HideInInspector]
    public static List<ChangingInput> Instances = new List<ChangingInput>();

    public KeyCode JumpKey = KeyCode.W;
    public KeyCode AccelerateKey = KeyCode.H;
	public KeyCode DecelerateKey = KeyCode.A;
	
	void Start()
	{
		Instances.Add(this);
	}

	public bool KeyPressed(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKeyDown(JumpKey) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKeyDown(AccelerateKey) ? true : false;

		if (key == KEYS.DECELERATE)
			return Input.GetKeyDown(DecelerateKey) ? true : false;

		return false;		
	}

	public bool KeyDown(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKey(JumpKey) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKey(AccelerateKey) ? true : false;
		
		if (key == KEYS.DECELERATE)
			return Input.GetKey(DecelerateKey) ? true : false;

		return false;
	}

	public bool KeyReleased(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKeyUp(JumpKey) ? true : false;

		if (key == KEYS.ACCELERATE)
			return Input.GetKeyUp(AccelerateKey) ? true : false;
		
		if (key == KEYS.DECELERATE)
			return Input.GetKeyUp(DecelerateKey) ? true : false;

		return false;
	}
}
