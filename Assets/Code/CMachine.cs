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
	}

	void Activate(){
		Enable();
		print ("Activate");
	}

	public void Enable(){
		gameObject.renderer.material = m_matActivated;
		m_bActivated = true;
		rigidbody.AddForce(new Vector3(0, 500000, 0));
	}
	
	public void Disable(){
		gameObject.renderer.material = m_matDisabled;
		m_bActivated = false;
	}
	
	public void OnMachineTriggerDown(){
		if(m_bActivated)
			Disable();
		else
			Enable();
	}
	
	public void OnMachineTrigger(){
		
	}
	
}
