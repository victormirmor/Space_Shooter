using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe_de_escena : MonoBehaviour {
	[Range(1, 100)]
	public int live=100;
	[Range(1, 10)]
	public int seg=3;
	[SerializeField]
	private GameObject _explosion;
	[Range(10, 500)]
	public int Score_Value;
	private Spawn_manager Spawn_Manager;

	void Start()
	{
		Spawn();
	}
	 void Spawn()
	 {
		 Spawn_Manager= GameObject.FindWithTag ("GameController").GetComponent<Spawn_manager> ();
	 }
 
	// Use this for initialization
	public void damage()
	{
		live = live - 1;
		if (live < 1) 
		{	

			Spawn_Manager.add_score (Score_Value);

			_explosion.SetActive (true);

			StartCoroutine (Boom());


			}
		}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {	
			Player.player player = other.GetComponent<Player.player> ();
			if (player != null) {
				player.damage ();
				damage ();
			}

		} else if (other.tag == "Shoot") {	
			Destroy (other.gameObject);
			damage ();

		}
	}
		public IEnumerator Boom()
	{
		yield return new WaitForSeconds (seg);
		if (transform.parent != null) {
			Destroy (transform.parent.gameObject);
			Destroy (this.gameObject);

		}
	}
}