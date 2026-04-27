using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Pausa : MonoBehaviour {
	

	public GameObject Canvas_Pausa;
	public GameObject BTN_Pausa;
	public bool Active_BTN_Pausa;

	void Awake()
		{
		Canvas_Pausa.SetActive (false);
		BTN_Pausa.SetActive (false);

		}

	void Update()
	{
		Pausa_Android();
	}
	void Pausa_Android()
	{
		if (Active_BTN_Pausa == false) 
		{
			BTN_Pausa.SetActive (false);
		} 
		else
		{
			BTN_Pausa.SetActive (true);
		}
	}
	public void level (string name)
	{ 
		SceneManager.LoadScene (name);

	}
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
	/*
	public void _Pausa()
		{
		Canvas_Pausa.SetActive(true);
		BTN_Pausa.SetActive (false);
	}*/
}