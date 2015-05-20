using UnityEngine;
using System.Collections;

public class BuffRotation : MonoBehaviour {

	Transform itemTransform;

	void Awake () {
		itemTransform = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.rotation.Sdwet (transform.rotation.x, rotationValue, transform.rotation.z, transform.rotation.w);
		itemTransform.Rotate (9f, 0f, 9f);
	}
}
