using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	static int nextFreeId = 0;

	int collisions;

	CharacterController characterController;
	public Vector2 Velocity = new Vector2(10, 0);

	public int id
	{
		get;
		private set;
	}

	public ChangingInput input
	{
		get;
		private set;
	}

	public PlayerSettings settings;

	public FiniteStateMachine<Player> fsm
	{
		get;
		private set;
	}

	public FSMState<Player> pStateJump
	{
		get;
		private set;
	}

	public FSMState<Player> pStateGlobal
	{
		get;
		private set;
	}

	public FSMState<Player> pStateGrounded
	{
		get;
		private set;
	}

	public FSMState<Player> pStateFall
	{
		get;
		private set;
	}

	public int points
	{
		get;
		set;
	}

	void Awake()
	{
		tag = PlayerSettings.Tag;
		gameObject.layer = LayerMask.NameToLayer(PlayerSettings.Tag);
		Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
	}

	// Use this for initialization
	void Start ()
	{
		id = nextFreeId++;

		input = GetComponent<ChangingInput>();
		characterController = GetComponent<CharacterController>();

		fsm = new FiniteStateMachine<Player>();

		pStateGlobal = ScriptableObject.CreateInstance<PStateGlobal>();

		pStateJump = ScriptableObject.CreateInstance<PStateJump>();
		pStateGrounded = ScriptableObject.CreateInstance<PStateGrounded>();
		pStateFall = ScriptableObject.CreateInstance<PStateFall>();

		fsm.Configure(this, pStateFall, pStateGlobal);

		collisions = 0;
		points = 0;
	}

	void Reset(Vector3 position)
	{
		transform.position = position;
		//rigidbody.velocity = Vector3.zero;
		fsm.ChangeState(pStateFall);
	}

	public void Die(Vector3 cameraPosition, Camera cam)
	{
		Vector3 newPos = cameraPosition;
		//newPos.x -= cam.GetScreenWidth() * 0.5f;
		newPos.y = PlayerSettings.SpawnPositionY;
		newPos.z = 0;

		// only spawn over a platform
		bool foundPlatform = false;
		int loopCountdown = 10;
		while (!foundPlatform)
		{
			RaycastHit hitInfo;
			// if there is nothing below for 10m, take a new position
			Physics.Raycast(newPos, Vector3.down, out hitInfo, 10.0f);

			if (hitInfo.collider == null)
			{
				newPos.x += PlayerSettings.PlatformSize;
			}
			else foundPlatform = true;

			if (loopCountdown-- <= 0)
				break;
		}

		Reset(newPos);
	}

	// Update is called once per frame
	void Update ()
	{
		if (characterController.isGrounded)
		{
			Velocity.y = 0;
			if (input.KeyDown(ChangingInput.KEYS.JUMP))
			{
				Velocity.y = settings.JumpSpeed;
			}
		}

		if (input.KeyDown(ChangingInput.KEYS.ACCELERATE))
		{
			Velocity.x = 15;
		}
		else if (input.KeyDown(ChangingInput.KEYS.DECELERATE))
		{
			Velocity.x = 1;
		}
		else
		{
			Velocity.x = 10;
		}

		Velocity.y -= settings.Gravity * Time.deltaTime;

		characterController.Move(new Vector3(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, 0));

		//fsm.Update();

		if (Input.GetKey(KeyCode.Space))
			Reset(new Vector3(0, 2, 0));
	}

	void FixedUpdate()
	{
		fsm.UpdateFixed();
	}

	void LateUpdate()
	{
		fsm.UpdateLate();
	}

	void OnCollisionEnter(Collision collision)
	{
		fsm.ChangeState(pStateGrounded);
		collisions++;
	}

	void OnCollisionExit(Collision collision)
	{
		collisions--;
		if (collisions <= 0)
			fsm.ChangeState(pStateFall);
	}
}
