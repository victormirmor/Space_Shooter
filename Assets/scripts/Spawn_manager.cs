using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawn_manager : MonoBehaviour {
	// Objetos para spawn.
	public GameObject[] Enemigos;
	[SerializeField]
	[Range(1, 20)]
	private int Seconds_enemigos=1;
	public GameObject[] Asteriodes;
	[SerializeField]
	[Range(1, 20)]
	private int Seconds_Asteriodes=1;
	public GameObject[] Poweup;
	[SerializeField]
	[Range(1, 20)]
	private int Seconds_Powerup=1;

	//Objetos para elementos UI
	private int score;
	/*[Range(0, 3)]
	public int Lifes=3;*/

	public Text text_player_score;

	public Image image_life;
	public Sprite[] lifes;

	public Text text_life_player;

	public Text text_game_score;

	public Text Game_Over;
	public Text reiniciar;

	public Text text_reiniciar;


	void Start () 
	{
		StartCoroutine (spawn_enemigos());
		StartCoroutine (Spaw_powerups());
		StartCoroutine (Spawn_Asteriodes());
		//GameOver ();
		text_reiniciar.enabled = false;
		Game_Over.enabled= false;
		reiniciar.enabled = false;
		score = 0;
		Update_Score ();

	}


	public void Update_Score()
	{
		text_player_score.text = "score: " + score;
		
	}
	public void Update_Live(int currentLives)
	{
		image_life.sprite=lifes[currentLives];

	}
	public void add_score(int value)
	{
		score+=	value;
		Update_Score();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	IEnumerator spawn_enemigos()
	{
		while (true) 
		{ 	float Random_X = Random.Range (-20f, 0f);
			//Vector3  Enemigo1=(Random_X,2.6f,0);
				
			Instantiate (Enemigos [0], new Vector3 (0f,2.6f,0) , Quaternion.identity);
			Instantiate (Enemigos [1], new Vector3 (Random_X,2.6f,0) , Quaternion.identity);
			Instantiate (Enemigos [2], new Vector3 (0f,2.6f,0) , Quaternion.identity);

			yield return new WaitForSeconds (Seconds_enemigos);
		}
	}

	IEnumerator Spaw_powerups()
	{
		while (true) 
		{ 	
			float Ran_x = Random.Range (-14.5f, 0f);
			int Powerups= Random.Range (0,3);

			Instantiate (Poweup [Powerups], new Vector3 (Ran_x,1.4f,0) , Quaternion.identity);
			yield return new WaitForSeconds (Seconds_Powerup);
		}
	}
	IEnumerator Spawn_Asteriodes()
	{
		while (true) 
		{ 	
			float Ran_x = Random.Range (-14.5f, 0f);
			int Random_Asteriodes= Random.Range (0, 3);

			Instantiate (Asteriodes [Random_Asteriodes], new Vector3 (Ran_x,1.4f,0) , Quaternion.identity);
			yield return new WaitForSeconds (Seconds_Asteriodes);
		}
	}
}
