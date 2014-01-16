using UnityEngine;
using System.Collections;

public class ScriptPiston : MonoBehaviour {

	
	public GameObject m_Rotor;
	bool activated = false;

	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<CBlocAReparer>().m_isRepaired && m_Rotor.GetComponent<CBlocAReparer>().m_isRepaired && GetComponent<ScriptEnergie>().Energie)
		{
			activated = true;
			animation.Play();
		}

		if(!GetComponent<ScriptEnergie>().Energie)
			animation.Stop ();
 
	}
}
