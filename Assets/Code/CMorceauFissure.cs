using UnityEngine;
using System.Collections;

public class CMorceauFissure : MonoBehaviour {

	public bool activated = false;
	public Material m_matActivated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSoudureTrigger(){
		Debug.Log ("WTF3");
		if(!activated){
			renderer.material=m_matActivated;
			activated = true;
		}
	}
}
