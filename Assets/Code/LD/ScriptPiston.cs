using UnityEngine;
using System.Collections;

public class ScriptPiston : MonoBehaviour {

	
	public GameObject m_Rotor;
	bool activated = false;
	public bool m_repaired;
	void Repair(){
		m_repaired = true;
	}
	

	// Use this for initialization
	void Start () {
		m_repaired = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if(m_repaired && m_Rotor.GetComponent<ScriptRotor>().m_repaired && GetComponent<ScriptEnergie>().Energie)
		{
			activated = true;
			animation.Play();
		}

		if(!GetComponent<ScriptEnergie>().Energie)
			animation.Stop ();

	}
}
