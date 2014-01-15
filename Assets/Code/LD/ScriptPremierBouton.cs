using UnityEngine;
using System.Collections;

public class ScriptPremierBouton : MonoBehaviour {

	bool isRepaired = false;

	void Repair(){
		isRepaired = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate(){
		if(isRepaired)
		{
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("TrucElectriques"))
			{
				obj.SendMessage("Energize");
			}
		}
	}
}
