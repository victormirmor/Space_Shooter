using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quality : MonoBehaviour {

//public Dropdown Dropdown;//invocamos el Dropdown 

	//asignar manualmente a botones
	//Puse solo 3, pero si tenemos mas niveles seria igual.
public void low()
	{
		QualitySettings.SetQualityLevel(0);
	}
	public void medios()
	{
		QualitySettings.SetQualityLevel(1);
	}
	public void altos()
	{
		QualitySettings.SetQualityLevel(2);
	}
}


//Asignar usando un Dropdown
/*void Update(){
switch (Dropdown.value)
{
case 0:
QualitySettings.SetQualityLevel(0);break;
case 1:
QualitySettings.SetQualityLevel(1);break;
case 2:
QualitySettings.SetQualityLevel(2);break;
case 3:
QualitySettings.SetQualityLevel(3);break;
case 4:
QualitySettings.SetQualityLevel(4);break;
case 5:
QualitySettings.SetQualityLevel(5);break;
  }
 }
}*/

