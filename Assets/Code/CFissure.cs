using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CFissure : MonoBehaviour {

	int m_nombreDeMorceaux = 0;
	List<bool> soude;
	bool repaired = false;


	void Awake() {
		soude = new List<bool>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(!soude.Contains(false) && !repaired){
			repaired = true;
			gameObject.transform.parent.SendMessage("Repair");
		}
	}

	void AttributeMorceauNumber(CMorceauFissure morceau){
		morceau.setID(soude.Count);
		//print(soude.Count);
		soude.Add(false);

	}

	void SoudageMorceau(int id){
		soude[id] = true;
	}

}
