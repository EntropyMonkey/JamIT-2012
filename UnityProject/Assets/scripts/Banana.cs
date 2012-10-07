using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour
{
	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.collider.tag == PlayerSettings.Tag)
		{
			Player player = other.gameObject.GetComponent<Player>();
            player.points++;
            Destroy(gameObject);
		}
	}
}