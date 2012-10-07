using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangingInput : MonoBehaviour
{
	public enum KEYS { JUMP, BOOST };

    [HideInInspector]
    public static List<ChangingInput> Instances = new List<ChangingInput>();

    public KeyCode JumpKey = KeyCode.W;
    public KeyCode BoostKey = KeyCode.H;
	
	void Start()
	{
		Instances.Add(this);
	}

	public bool KeyPressed(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKeyDown(JumpKey) ? true : false;

		if (key == KEYS.BOOST)
			return Input.GetKeyDown(BoostKey) ? true : false;

		return false;		
	}

	public bool KeyDown(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKey(JumpKey) ? true : false;

		if (key == KEYS.BOOST)
			return Input.GetKey(BoostKey) ? true : false;

		return false;
	}

	public bool KeyReleased(KEYS key)
	{
		// TODO map the key to the according currently active keyboard key
		if (key == KEYS.JUMP)
            return Input.GetKeyUp(JumpKey) ? true : false;

		if (key == KEYS.BOOST)
			return Input.GetKeyUp(BoostKey) ? true : false;
		
		return false;
	}
}
