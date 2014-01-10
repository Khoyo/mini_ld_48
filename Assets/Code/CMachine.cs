using UnityEngine;
using System.Collections;

public class CMachine : MonoBehaviour {
	
	public Material m_matActivated;
	public Material m_matDisabled;
	public bool m_bActivated = false;
	
	void Start(){
		gameObject.renderer.material = m_matDisabled;
	}
	
	void Update(){
		//gameObject.renderer.material = m_bActivated ? m_matActivated : m_matDisabled;
	}
	
}
