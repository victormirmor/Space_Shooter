using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class pause_manager : MonoBehaviour {
    [Range(1, 2)]
    public int canvas_ID = 1;
    Canvas canvas;
	void Start()
	{

		if (canvas_ID == 1) {
			canvas = GetComponent<Canvas> ();
			canvas.enabled = false;
			Time.timeScale = 1;
			}
		if (canvas_ID == 2) {
			canvas = GetComponent<Canvas> ();
			canvas.enabled = true;
			Time.timeScale = 1;
		}
	}
	void Update()
	{
		if (Input.GetButtonDown ("Cancel"))
		{
			Pause();
		}
	}
    // Este canvas se activa presionando un boton y entrando en modo pausa.
    //This canvas enabled held down button and entering pause mode.
    
//"pause" cambia de estado el camvas, de activado a desactivado y alreves
//"pause" changes state canvas , activated to deactivated and deactivated to activated
    
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
    }

//Carga la escena name
// Load Scene name
public void scene(string name)
	{ 
		SceneManager.LoadScene (name);

	}
 
//Exit the game, "#if UNITY_EDITOR" is used only when in unity
//Sale del juego, "#if UNITY_EDITOR" se usa solo estando en unity
public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}