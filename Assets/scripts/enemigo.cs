using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {
	public float speed;
	public GameObject SpawnManager;
	void Update () 
	{
		move ();
		limit ();

	}

	void move ()
	{
		transform.Translate (Vector3.down* speed*Time.deltaTime);
	}

	void limit()
	{
		if (transform.position.y <= -9.6f) 
		{
			if (transform.parent != null) 
			{
				Destroy (transform.parent.gameObject);
			}
		Destroy (this.gameObject);

		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (transform.parent != null) 
			{
				Destroy (transform.parent.gameObject);
			}	
			Player.player player = other.GetComponent<Player.player> ();
			if (player != null) {
				player.damage ();
				Destroy (this.gameObject);
			}

		} 
		else if (other.tag == "Shoot") 
		{
			if (transform.parent != null) 
			{
				Destroy (transform.parent.gameObject);
			}	
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}

}
