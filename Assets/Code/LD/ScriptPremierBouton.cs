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

	void OnMachineTrigger(){
		if(isRepaired)
		{
			foreach(ScriptEnergie scr in transform.parent.GetComponentsInChildren<ScriptEnergie>())
			{
				scr.Energize();
			}
		}
	}
}
