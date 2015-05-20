using UnityEngine;
using System.Collections;

public class BuffRotation : MonoBehaviour {

	Transform transform;

	void Awake () {
		transform = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.rotation.Sdwet (transform.rotation.x, rotationValue, transform.rotation.z, transform.rotation.w);
		transform.Rotate (9f, 0f, 9f);
	}
}
