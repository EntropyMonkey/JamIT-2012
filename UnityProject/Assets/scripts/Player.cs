using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	static int nextFreeId = 0;

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

	}

	void Reset()
	{
		transform.position = new Vector3(0, 2, 0);
		rigidbody.velocity = Vector3.zero;
		fsm.ChangeState(pStateRun);
	}
	
	// Update is called once per frame
	void Update () 
	{
		fsm.Update();

		if (Input.GetKey(KeyCode.Space))
			Reset();
	}

	void OnCollisionEnter(Collision collision)
	{
		fsm.ChangeState(pStateRun);
	}

	void OnCollisionExit(Collision collision)
	{
		fsm.ChangeState(pStateFall);
	}
}
