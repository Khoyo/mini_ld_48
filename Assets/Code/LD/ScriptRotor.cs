using UnityEngine;
using System.Collections;

public class ScriptRotor : MonoBehaviour {

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
	}


}
