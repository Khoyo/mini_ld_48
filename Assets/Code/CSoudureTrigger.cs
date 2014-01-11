using UnityEngine;
using System.Collections;

public class CSoudureTrigger : MonoBehaviour {

	float timer, lastActivated;
	
	// Use this for initialization
	void Start () {
		timer=lastActivated=Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider col){

		if(col.gameObject.name != "Fer")
			return;
		timer = Time.time;
		if(CApoilInput.InputPlayer.InteractFer){
			SendMessageUpwards("OnSoudureTrigger", SendMessageOptions.DontRequireReceiver);
			if((timer-lastActivated)>0.05){
				SendMessageUpwards("OnSoudureTriggerDown", SendMessageOptions.DontRequireReceiver);
			}
			lastActivated = Time.time;
		}
	}
}
