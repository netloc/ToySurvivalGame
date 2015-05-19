using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	PlayerBuffs playerBuffs;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();

		playerBuffs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBuffs>();

		// Would set the root motion to true, already checked in unity properties
		//anim.applyRootMotion = true;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		//If the player has hit the speed buff
		if (playerBuffs.hasSpeedBuff)
		{
			//If the player has the buff used the increased speed from the playbuffs script instead of the base speed
			movement = movement.normalized * playerBuffs.speed * Time.deltaTime;
		}
		else
		{
			// Move 6 units a second and normalize it so that it is the same speed in any direction as well as per second.
			movement = movement.normalized * speed * Time.deltaTime;
			playerBuffs.RemoveSpeedBonus();
		}

		// Moves
		playerRigidbody.MovePosition (transform.position + movement);

	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}



















