using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shoot{
public class shoot : MonoBehaviour {
	[Range(10.0f, 100.0f)]
    public float speed =80.0F;
	void Update () {
			transform.Translate(0,speed * Time.deltaTime, 0 );

			if (transform.position.y > 9.5f)
			{
				
			if (transform.parent != null) 
			{
				Destroy (transform.parent.gameObject);
			}
					
				Destroy (this.gameObject);
			}
	}
}
}