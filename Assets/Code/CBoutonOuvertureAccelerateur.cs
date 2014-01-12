using UnityEngine;
using System.Collections;

public class CBoutonOuvertureAccelerateur : MonoBehaviour {

	bool m_isRepaired = false;
	public GameObject m_gameObjectToActivate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Repair() {
		m_isRepaired = true;
		print ("Repaired");
	}

	void OnMachineTriggerDown(){
		print ("triggered");
		if(m_isRepaired){
			print ("Sended");
			m_gameObjectToActivate.SendMessage("Activate");
		}
	}
}
