using UnityEngine;
using System.Collections;

public class CMorceauFissure : MonoBehaviour {

	public bool activated = false;
	public Material m_matActivated;
	Material m_baseMat;

	int m_id;

	// Use this for initialization
	void Start () {
		m_baseMat = renderer.material;
		activated = false;
		m_id = -1;
		SendMessageUpwards("AttributeMorceauNumber", this);
	}
	
	public void Desolder(){
		activated = false;
		renderer.material = m_baseMat;
	}

	public void OnSoudureTrigger(){

		if(!activated){
			renderer.material=m_matActivated;
			activated = true;
			SendMessageUpwards("SoudageMorceau", m_id, SendMessageOptions.RequireReceiver);
		}
	}

	public void setID(int id){
		m_id = id;
	}

	public int getID(){
		return m_id;
	}
}
