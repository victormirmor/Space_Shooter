using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(BoxCollider))]

public class player : MonoBehaviour {

	[SerializeField]
	[Range(1.0f, 10.0f)]
    float speed=5;
	[SerializeField]
	[Range(1, 4)]
	private int PlayerID=1;
	public string eje_horizontal_Player;
	public string eje_vertical_Player;
	public string boton_disparo;
	[Range(0, 8)]public int live=3;
	public GameObject lazer;// un disparo simple,un lazer y un script de disparo.
	public GameObject triple;
	public bool Triple_shootS=false;
	public bool IsSpeedBoostActive=false;
	[SerializeField]
	[Range(0.01f, 2.0f)]
	private float fireRate = 0.5F;
	[SerializeField]
		private Vector2 limites;
	[SerializeField]
	[Range(0.01f, 1.0f)]
	private float nextFire = 0.1F;
	[SerializeField]
	[Range(1.0f, 10.0f)]
	float tiempo_explosion=5f;
	[SerializeField]
	private GameObject _explosion;
	private Spawn_manager Spawn_Manager;

		void Start()
		{
			Spawn_Manager= GameObject.FindWithTag ("GameController").GetComponent<Spawn_manager> ();
			if (Spawn_Manager != null) 
			{	_explosion.SetActive(false);
				Spawn_Manager.Update_Live(live);
				}
				

		}


void Update () 
{
		movement ();
		limitsY (); 
		limitsX ();

	if(live>=9){
		live=9;
		}
	else if(live<0){
		live=0;
		}
}
		
	void  movement (){
			if (PlayerID == 1){

			float Horizontal=Input.GetAxis(eje_horizontal_Player);
			float Vertical = Input.GetAxis (eje_vertical_Player);

			if (IsSpeedBoostActive == true) 
			{
					transform.Translate (new Vector3 (Horizontal, 0, Vertical) * speed * 2.0f * Time.deltaTime);	
			} else
			{
					transform.Translate( new Vector3 (Horizontal,0,Vertical)*speed*Time.deltaTime);	
				}
			}
		}
		public void damage(){
			if (PlayerID == 1)
		{
			live = live - 1;
			Spawn_Manager.Update_Live(live);
			//Spawn_Manager.Game_Over.true;
				if (live < 1) {	
					_explosion.SetActive (true);
					StartCoroutine (muerte ());
					}
				}
	}
	//Limitamos el movimiento en el eje Y
	void limitsY()
	{
			if (transform.position.y > limites.y) 
			{
				transform.position = new Vector2 (transform.position.x, limites.y);
			} 
			else if (transform.position.y < -limites.y) 
			{
				transform.position = new Vector2 (transform.position.x, -limites.y);
			}
	}
	//limitamos el movimiento en el eje X

	void Shooting(){
		if (Input.GetButtonDown (boton_disparo)){
					Shoot ();
					}
	}
	void limitsX ()
	{
		if (transform.position.x > limites.x) 
			{
				transform.position = new Vector2 (-limites.x, transform.position.y);
			} 
			else if (transform.position.x < -limites.x) 
			{
			transform.position = new Vector3 (limites.x, transform.position.y,transform.position.z);
			}
	}
		//Aqui llamo al disparo "shoot"
		void Shoot () {
			if (Time.time > nextFire){
		if (Triple_shootS == true)
			{
			Instantiate (triple, transform.position, Quaternion.identity);
			}
		else
			{
				Instantiate (lazer, transform.position, Quaternion.identity);
			}
		 {
			nextFire = Time.time + fireRate;
		 }	
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
	public void New_Boost()
	{
			IsSpeedBoostActive=true;
			StartCoroutine (Boost());
	}
	public IEnumerator Boost()
	{
		yield return new WaitForSeconds (5.0f);
		IsSpeedBoostActive = false;
			
	 } 
		public IEnumerator muerte()
		{
			yield return new WaitForSeconds (tiempo_explosion);
			Destroy (this.gameObject);

				
		}
	}
}