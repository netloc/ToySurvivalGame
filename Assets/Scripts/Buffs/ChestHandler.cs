using UnityEngine;
using System.Collections;

public class ChestHandler : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent <Animator> ();
		anim.applyRootMotion = true;
	}

	void Update()
	{

	}
	
	void OnTriggerEnter(Collider other)
	{
		if ("Player" == other.gameObject.tag)
		{
			anim.SetTrigger("IsTouched");
		}
		else
		{
			anim.ResetTrigger("IsTouched");
		}
	}


}
