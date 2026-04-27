using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PowerUps{
	
[RequireComponent(typeof(SphereCollider))]
public class Powerup_Boost : MonoBehaviour {
		[SerializeField]
		[Range(0.0f, 5.0f)]
		float speed=0.0f;
		[Range(0, 2)]
		[SerializeField]
		private int serialID=0; //o=triple shoot, 1= Power Boost, 2= health.

		void Update ()
		{
			Move ();
			limit ();
		}


		void Move ()
		{
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player") 
			{	
				Player.player player = other.GetComponent<Player.player> ();
				if (player != null) 
				{
					//Asignaoms el SerialID
					{
						if (serialID == 0) 
						{
							player.shootpoweron ();
						} 
						else if (serialID == 1) 
						{
							player.New_Boost();
						} 
						else if (serialID == 2) 
						{
							player.live += 1;
						}
						Destroy (this.gameObject);
				}

			}
		}
	
	}

		void limit()
		{
			if (transform.position.y <= -9.6f) 
			{
				Destroy (this.gameObject);
			}
		}
  }
}