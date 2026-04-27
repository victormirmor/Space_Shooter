using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PowerUps{
public class Powerup_triple_shoot : MonoBehaviour {
		[SerializeField]
		[Range(0.0f, 5.0f)]
		float speed=0.0f;
	
		void Update () 
		{
			transform.Translate (Vector3.down*speed*Time.deltaTime);
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player") 
			{	
				Player.player player = other.GetComponent<Player.player> ();
				if (player != null) 
				{
					player.shootpoweron();
				}
				Destroy (this.gameObject);
			}
			else if (other.tag == "Player2")
			{
				Player.player2 player2 = other.GetComponent<Player.player2> ();
				if (player2 != null) 
				{	
					player2.shootpoweron();
				}
				Destroy (this.gameObject);
			}
		}
	}
}

