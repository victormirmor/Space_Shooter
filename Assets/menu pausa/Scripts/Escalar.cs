using UnityEngine;
using System.Collections;

public class Escalar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(960, 540, false);
	}
	public void calidad_cero ()
	{
		QualitySettings.SetQualityLevel(0);
	}
	public void calidad_uno()
	{
		QualitySettings.SetQualityLevel(1);
	}
	public void calidad_dos ()
	{
		QualitySettings.SetQualityLevel(2);
	}
	public void calidad_tres ()
	{
		QualitySettings.SetQualityLevel(3);
	}
	public void calidad_cuatro ()
	{
		QualitySettings.SetQualityLevel(4);
	}
	//Vsync off
	public void vsyncoff(){
		QualitySettings.vSyncCount = 0;
	}
	//Vsync 60 fps
	public void vsync60()
	{
		QualitySettings.vSyncCount = 1;
	}
	//Vsync 30 fps
	public void vsync30()
	{
		QualitySettings.vSyncCount = 2;
	}
}
