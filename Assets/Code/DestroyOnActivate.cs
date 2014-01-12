using UnityEngine;
using System.Collections;

public class DestroyOnActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate(){
		GameObject.Destroy(gameObject);
	}
}
