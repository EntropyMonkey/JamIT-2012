using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	ChangingInput input;


	// Use this for initialization
	void Start () 
	{
		input = GetComponent<ChangingInput>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
