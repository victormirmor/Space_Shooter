using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shoot{
public class shoot2 : MonoBehaviour {
	[Range(10.0f, 100.0f)]
    public float speed =80.0F;
	void Update () {
		 transform.Translate(Vector3.up);

			if (transform.position.y > 9.5f)
			{

				if (transform.parent != null) 
				{
					Destroy (transform.parent.gameObject);
				}

				Destroy (this.gameObject);
			}


	}
		/*void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Enemy") {	
				Player.player player = other.GetComponent<Player.player> ();
				Jefe_de_escena.Destroy;
			if (player != null) {
					player.damage ();
				}

			}
 }*/
}
}