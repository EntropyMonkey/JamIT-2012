using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	static int nextFreeId = 0;

	CharacterController characterController;
	public Vector2 Velocity = new Vector2(10, 0);

    public float DeathTimePenalty = 2.0f;
    private float timeSinceDeath = 0F;

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

	public int points
	{
		get;
		set;
	}

    private bool dead = false;

	void Awake()
	{
		tag = PlayerSettings.Tag;
		gameObject.layer = LayerMask.NameToLayer(PlayerSettings.Tag);
		Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
	}

	// Use this for initialization
	void Start()
	{
		id = nextFreeId++;

		input = GetComponent<ChangingInput>();
		characterController = GetComponent<CharacterController>();

		points = 0;

        /*var color = renderer.material.color;
        color.a = 255;
        renderer.material.color = color;*/
		renderer.material.color = settings.Color;
	}

	void Reset(Vector3 position)
	{
		transform.position = position;
	}

	public void Die()
	{
        timeSinceDeath = 0;
        dead = true;
	}

	// Update is called once per frame
	void Update()
	{
		timeSinceDeath += Time.deltaTime;	
        if (dead == true && timeSinceDeath > DeathTimePenalty)
        {
            Respawn();
        }
        else
        {
            if (characterController.isGrounded)
            {
                Velocity.y = 0;
                if (input.KeyDown(ChangingInput.KEYS.JUMP))
                {
                    Velocity.y = settings.JumpSpeed;
                }
            }

            Velocity.x = 10;

            Velocity.y -= settings.Gravity * Time.deltaTime;

            characterController.Move(new Vector3(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime, 0));

            if (Input.GetKey(KeyCode.Space))
                Reset(new Vector3(0, 2, 0));
        }
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.normal.y < 0)
		{
			Velocity.y = 0;
		}
	}

    private void Respawn()
    {
		if(Camera.current != null)
		{
	        Vector3 newPos = Camera.current.transform.position;
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
			dead = false;
			timeSinceDeath = 0F;
	        Reset(newPos);
		}
    }

}
