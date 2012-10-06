﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerSettings
{
	public float MaxRunSpeed = 10;
	public float StandardRunSpeed = 5;
	public float ToStandardSpeedSmoothing = 2;
	public float DecelerateSpeed = 2;

	public float MaxJumpTime = 0.2f;
	public Vector2 JumpSpeed = new Vector2(0, 80);

	public const string Tag = "Player";

	public const float SpawnPositionY = 2;
	public const float PlatformSize = 3.7f;
}