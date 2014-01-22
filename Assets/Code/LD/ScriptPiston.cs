using UnityEngine;
using System.Collections;

public class ScriptPiston : MonoBehaviour {

	
	public GameObject m_Rotor;
	bool activated = false;
	public float m_fSpeed = 1;



	// Use this for initialization
	void Start () {
		foreach (AnimationState state in animation) {
			state.speed = m_fSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_Rotor.GetComponent<CBlocAReparer>().m_isRepaired && GetComponent<ScriptEnergie>().Energie)
		{
			activated = true;
			animation.Play();
		}

		if(!GetComponent<ScriptEnergie>().Energie)
			animation.Stop ();
 
	}
}
