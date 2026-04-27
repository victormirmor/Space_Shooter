using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Boom ());
	}
	public IEnumerator Boom()
	{
		yield return new WaitForSeconds (10.0f);
		Destroy (this.gameObject);

	}
}
