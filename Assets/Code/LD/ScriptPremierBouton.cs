using UnityEngine;
using System.Collections;

public class ScriptPremierBouton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMachineTrigger(){
		if(GetComponent<CBlocAReparer>().m_isRepaired)
		{
			foreach(ScriptEnergie scr in transform.parent.GetComponentsInChildren<ScriptEnergie>())
			{
				scr.Energize();
			}
		}
	}
}
