using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerSettings
{
	public float Gravity = 9.8f;
	public float JumpSpeed = 15;

	//public float MaxRunSpeed = 10;
	//public float StandardRunSpeed = 5;
	//public float ToStandardSpeedSmoothing = 2;
	//public float DecelerateSpeed = 2;

	//public float MaxJumpTime = 0.2f;
	//public Vector2 JumpSpeed = new Vector2(0, 80);

	public Color Color;

	public const string Tag = "Player";

	public const float SpawnPositionY = 2;
	public const float PlatformSize = -0.5f;
}