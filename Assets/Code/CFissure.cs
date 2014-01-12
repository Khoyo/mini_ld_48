using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CFissure : MonoBehaviour {

	int m_nombreDeMorceaux = 0;
	List<bool> soude;
	bool repaired = false;
	bool soldering = false;

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

		if(soldering && !repaired &&  !CApoilInput.InputPlayer.InteractFer)
			Desolder();
	}

	void AttributeMorceauNumber(CMorceauFissure morceau){
		morceau.setID(soude.Count);
		//print(soude.Count);
		soude.Add(false);

	}

	void Desolder(){
		soldering = false;
		for(int i = 0; i < soude.Count; i++)
			soude[i] = false;
		CMorceauFissure[] morceaux = GetComponentsInChildren<CMorceauFissure>();
		foreach(CMorceauFissure m in morceaux)
			m.Desolder();
		repaired = false;
	}

	bool isDesoldered(){
		return (!repaired) && (!soldering);
	}

	void SoudageMorceau(int id){
		if(!soldering)
			soldering = true;
		soude[id] = true;
	}

}
