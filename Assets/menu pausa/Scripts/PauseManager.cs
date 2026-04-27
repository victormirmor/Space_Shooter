using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseManager : MonoBehaviour {
	//compatible version 4.7.2

    Canvas canvas;
    
void Start()
    //este canvas por defecto esta desactivado
    {
canvas = GetComponent<Canvas>();
canvas.enabled = false;
/*Agregado para evitar que la pausa se aplique
al volver desde el menú principal.*/
Time.timeScale = 1;

}

	public void level (string name)
	{
		SceneManager.LoadScene (name);
	}
	// Este canvas se activa presionando un boton y entrando en modo pausa.
    void Update()
    {
		if (Input.GetButtonDown ("Cancel"))
		{
            Pause();
		}
}
//"pause" cambia de estado el camvas, de activado a desactivado y alreves
    
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Time.timeScale = Time.timeScale == 0 ? 1: 0;
    }
//Sale del juego, "#if UNITY_EDITOR" se usa solo estando en unity
	public void mascalidad()
	{
		QualitySettings.IncreaseLevel();
	
	}
	public void menoscalidad()
	{
		QualitySettings.DecreaseLevel();
	}
	public void Antialias_off()
	{
	QualitySettings.antiAliasing = 0;
	Debug.Log ("0 AA");
	}
	public void Antialias_2()
	{
		QualitySettings.antiAliasing = 2;
		Debug.Log ("2 AA");
	}
	public void Antialias_4()
	{
		QualitySettings.antiAliasing = 4;
		Debug.Log ("4 AA");
	}
	public void Antialias_8()
	{
		QualitySettings.antiAliasing = 8;
		Debug.Log ("8 AA");
	}
	//1080P pantalla completa
	public void FULLHD(){
	Screen.SetResolution(1920, 1080, true);
	}
	//720p pantalla completa
	public void HD() {
		Screen.SetResolution(1280, 720, true);

		}
	//720p ventana
	public void HDFalse() {
		Screen.SetResolution(1280, 720, false);
	}
	//768 4/3 VENTANA
	public void SIETESEIS() {
		Screen.SetResolution(1024, 768, true);
	}
	//1024 5/4 VENTANA
	public void MILVEINTI() {
		Screen.SetResolution(1280, 1024, true);
	}
	//800 VENTANA
	public void OCHOCIENTOS() {
		Screen.SetResolution(800, 600, false);
	}


public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
  }