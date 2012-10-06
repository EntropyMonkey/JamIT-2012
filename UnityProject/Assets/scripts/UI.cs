using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	GameObject[] players;
	
	void Start()
	{
		players = GameObject.FindGameObjectsWithTag(PlayerSettings.Tag);
	}

	void OnGUI()
	{
		float y = 10;

		foreach (GameObject go in players)
		{
			Player p = go.GetComponent<Player>();
			GUI.Box(new Rect(10, y, 500, 25), "Player " + p.id + ": Decelerate-> " + p.input.DecelerateKey + " Jump-> " + p.input.JumpKey + " Accelerate-> " + p.input.AccelerateKey);
			y += 30;
		}
	}
}