using UnityEngine;
using System.Collections;

public class MonkeyCamera : MonoBehaviour 
{
	GameObject[] monkeys;

	public float WayIn1Second;

	// Use this for initialization
	void Start () 
	{
		monkeys = GameObject.FindGameObjectsWithTag(PlayerSettings.Tag);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// kill monkeys outside the screen
		foreach (GameObject monkey in monkeys)
		{
			if (!monkey.renderer.isVisible)
			{
				monkey.GetComponent<Player>().Die(transform.position);
			}
		}

		// make the camera move
		Vector3 pos = transform.position;
		pos.x = Mathf.Lerp(pos.x, pos.x + WayIn1Second, Time.deltaTime);
		transform.position = pos;
	}
}
