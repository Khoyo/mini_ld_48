using UnityEngine;
using System.Collections;

public class ScriptEnergie : MonoBehaviour {

	public bool Energie;
	float tempsRestant;

	void Start(){
		tempsRestant = 0;
	}

	void Update(){
		tempsRestant -= Time.deltaTime;
		Energie = tempsRestant > 0;
	}

	void Energize(){
		tempsRestant = 15;
	}
}
