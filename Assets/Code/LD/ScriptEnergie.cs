using UnityEngine;
using System.Collections;

public class ScriptEnergie : MonoBehaviour {

	public bool Energie;
	public float tempsRestant;

	void Start(){
		tempsRestant = 0;
	}

	void Update(){
		tempsRestant -= Time.deltaTime;
		Energie = tempsRestant > 0;
	}

	public void Energize(){
		tempsRestant = 50;
		Debug.Log ("Kirk : energize.");
	}
}
