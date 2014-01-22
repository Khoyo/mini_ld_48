using UnityEngine;
using System.Collections;

public class ScriptRotor : MonoBehaviour {

	public float m_fSpeed = 1;

	// Use this for initialization
	void Start () {
		foreach (AnimationState state in GetComponentInChildren<Animation>()) {
			state.speed = m_fSpeed;
		}
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
