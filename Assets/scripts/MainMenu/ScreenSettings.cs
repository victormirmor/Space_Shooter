using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScreenSettings : MonoBehaviour {
	public Dropdown DropdownResolution,DropdownScreen;
	private Resolution[] resolucionesHardware; // Variable global del script
	public bool IsFull;

	void Awake(){
		DropdownResolution.value = PlayerPrefs.GetInt("Resolution");
		DropdownScreen.value = PlayerPrefs.GetInt("Screen");
	}

	void Start() {
		resolucionesHardware = Screen.resolutions;
		DropdownResolution.ClearOptions();
		List<string> opciones = new List<string>(); // 3. Crear una lista de strings para mostrar en el menú
		int indiceActual = 0;
		for (int i = 0; i < resolucionesHardware.Length; i++) {			
			string opcion = resolucionesHardware[i].width + " x " + resolucionesHardware[i].height; // Formateamos el texto: "1920 x 1080"
			opciones.Add(opcion);
			if (resolucionesHardware[i].width == Screen.currentResolution.width && // 4. Detectar cuál es la resolución que está usando el monitor ahora mismo
				resolucionesHardware[i].height == Screen.currentResolution.height) {
				indiceActual = i;
				}
		}
		DropdownResolution.AddOptions(opciones);// 5. Añadir la lista al Dropdown y marcar la actual
		DropdownResolution.value = indiceActual;
		DropdownResolution.RefreshShownValue();
	}

	public void SetResolution(int Level) {		
		if (resolucionesHardware == null || resolucionesHardware.Length == 0) return; // 1. Verificamos que el arreglo no esté vacío
		Resolution resElegida = resolucionesHardware[Level]; // 2. Obtenemos la resolución según el "Level" que mandó el Dropdown
		Screen.SetResolution(resElegida.width, resElegida.height, IsFull);// 3. Aplicamos la resolución usando tu variable IsFull
		PlayerPrefs.SetInt("Resolution", Level);// 4. Guardamos el índice para la próxima vez
	#if UNITY_EDITOR
	Debug.Log("Cambiado a: " + resElegida.width + "x" + resElegida.height);
	#endif
	}

	public void fullScreen(int Level){
		if(Level==0){Screen.fullScreen = false;}
		if(Level==1){Screen.fullScreen = true;}
		PlayerPrefs.SetInt("Screen",DropdownScreen.value);
		#if UNITY_EDITOR
		Debug.Log("fullScreen= "+DropdownScreen.value);
		#endif
	}
}