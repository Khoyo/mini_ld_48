using UnityEngine;
using System.Collections;

public class ScriptRotor : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {		
		if(GetComponent<ScriptEnergie>().Energie)
		{
			foreach(Animation anim in GetComponentsInChildren<Animation>())
			        anim.Play();
		}
		else
			foreach(Animation anim in GetComponentsInChildren<Animation>())
				anim.Stop();
	}


}
