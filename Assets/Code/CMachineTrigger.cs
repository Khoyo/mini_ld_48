using UnityEngine;
using System.Collections;

public class CMachineTrigger : MonoBehaviour {
	
	float timer, lastActivated;
	
	// Use this for initialization
	void Start () {
		timer=lastActivated=Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(){zzz
		timer = Time.time;
		if(CApoilInput.InputPlayer.InteractHand){
			SendMessageUpwards("OnMachineTrigger", SendMessageOptions.DontRequireReceiver);
			if((timer-lastActivated)>0.05){
				SendMessageUpwards("OnMachineTriggerDown", SendMessageOptions.DontRequireReceiver);
			}
			lastActivated = Time.time;
		}
	}
}

	
	
	
	
	