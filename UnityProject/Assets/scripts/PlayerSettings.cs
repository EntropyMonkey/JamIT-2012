using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerSettings
{
	public float MaxRunSpeed;
	public float StandardRunSpeed;
	public float ToStandardSpeedSmoothing;
	public float DecelerateSpeed;

	public float MaxJumpTime;
	public float JumpSpeed;
}