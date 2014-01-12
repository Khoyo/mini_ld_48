using UnityEngine;
using System.Collections;

public class TestDlaSoudure : MonoBehaviour {

	public Material mactive;
	bool bactive = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void Activate(){
		if(!bactive){
			renderer.material = mactive;
			bactive = true;
		}
	}


}
