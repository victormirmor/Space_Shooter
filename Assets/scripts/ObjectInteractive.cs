using UnityEngine;
using System.Collections;

public class ObjectInteractive : MonoBehaviour 
{
[Tooltip("Objeto que quieres activar")]
[SerializeField]GameObject m_ObjectAnimation;
private Animator anim;

	void Start ()
	{ 	anim =m_ObjectAnimation.GetComponent<Animator>();
		m_ObjectAnimation.GetComponent<MeshRenderer> ().enabled = false;
		anim.SetBool("activar",false);
	}

	public void ActiveObject()

	{
		m_ObjectAnimation.SetActive(true);
		anim.SetBool("activar",true);
	}

}
