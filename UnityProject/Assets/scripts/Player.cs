using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	static int nextFreeId = 0;

	int collisions;

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

	public FSMState<Player> pStateRun
	{
		get;
		private set;
	}

	public FSMState<Player> pStateFall
	{
		get;
		private set;
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

		fsm = new FiniteStateMachine<Player>();

		pStateJump = ScriptableObject.CreateInstance<PStateJump>();
		pStateRun = ScriptableObject.CreateInstance<PStateRun>();
		pStateFall = ScriptableObject.CreateInstance<PStateFall>();

		fsm.Configure(this, pStateRun, null);

		collisions = 0;
	}

	void Reset(Vector3 position)
	{
		transform.position = position;
		rigidbody.velocity = Vector3.zero;
		fsm.ChangeState(pStateRun);
	}

	public void Die(Vector3 cameraPosition)
	{
		Vector3 newPos = cameraPosition;
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
		fsm.Update();

		if (Input.GetKey(KeyCode.Space))
			Reset(new Vector3(0, 2, 0));
	}

	void OnCollisionEnter(Collision collision)
	{
		fsm.ChangeState(pStateRun);
		collisions++;
	}

	void OnCollisionExit(Collision collision)
	{
		collisions--;
		if (collisions <= 0)
			fsm.ChangeState(pStateFall);
	}
}
