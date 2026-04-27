using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour {

	// Use this for initialization
	void Start () 
		{
			Time.timeScale = Time.timeScale == 1 ? 0 : 1;
		}
	
	// Update is called once per frame
	void Update () {
		
	}
}
