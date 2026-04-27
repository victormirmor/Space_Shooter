using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(BoxCollider))]

public class player2 : MonoBehaviour {
	[SerializeField]
	[Range(1.0f, 10.0f)]
    float speed=5;
	float Horizontal; 
	float Vertical;
	public GameObject lazer;// un disparo simple,un lazer y un script de disparo.
	public GameObject triple;
	public bool Triple_shootS=false;
	[SerializeField]
	[Range(0.01f, 2.0f)]
	private float fireRate = 0.5F;
	[SerializeField]
	[Range(0.01f, 1.0f)]
	private float nextFire = 0.1F;


void Update () 
{
		movement ();
		limitsY (); 
		limitsX (); 
		if (Input.GetButtonDown("Fire1_2"))
		Shoot ();
}

	void  movement ()
	{
		Horizontal=Input.GetAxis("Horizontal_2");
		Vertical = Input.GetAxis ("Vertical_2");
		transform.Translate( new Vector3 (Horizontal,0,Vertical)*speed*Time.deltaTime);	
	}

	//Limitamos el movimiento en el eje Y
	void limitsY()
	{
		if (transform.position.y > 7.2f) {
			transform.position = new Vector3 (transform.position.x, 7.2f, 0);
		} else if (transform.position.y < -7.2f) {
			transform.position = new Vector3 (transform.position.x, -7.2f, 0);
		}
	}
	//limitamos el movimiento en el eje X
	void limitsX ()
	{
		if (transform.position.x > 12.4f) {
			transform.position = new Vector3 (-12.4f, transform.position.y, 0);
		} else if (transform.position.x < -12.8f) {
			transform.position = new Vector3 (12.4f, transform.position.y, 0);
		}
	}
		//Aqui llamo al disparo "shoot"
		void Shoot () {
		if (Time.time > nextFire)
		if (Triple_shootS == true)
		{
			Instantiate (triple, transform.position , Quaternion.identity);
		}
		else{
			Instantiate (lazer, transform.position /*+ new Vector3 (2.31f,-3.21f, -8f)*/, Quaternion.identity);
		}
		 {
			nextFire = Time.time + fireRate;
			}
		}
	public void shootpoweron()
	{
		Triple_shootS = true;
		StartCoroutine (tripleshotcorrrutine ());
	}
	public IEnumerator tripleshotcorrrutine()
	{
		yield return new WaitForSeconds (5.0f);
		Triple_shootS = false;
	}
	}
}