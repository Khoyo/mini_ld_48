using UnityEngine;
using System.Collections;

public class CAccelerateur : MonoBehaviour {

	bool m_isOpened = false;
	public GameObject m_Game;
	
	public float m_fLife;
	bool m_bRepaired = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!m_bRepaired)
			m_fLife -= Time.deltaTime;
		if(m_fLife<0)
			m_Game.GetComponent<CGame>().EndGame(false);
	}

	public void Open(){
		animation.PlayQueued("Ouverture");
		m_isOpened = true;
		m_Game.GetComponent<CGame>().GetSoundEngine().postEvent("Play_DoorOver", gameObject);


	}

	void Repair(){
		m_bRepaired = true;
	}

	public void Close()
	{
		if(m_isOpened){
			animation.PlayQueued("Fermeture");
			m_isOpened = false;
			m_Game.GetComponent<CGame>().GetSoundEngine().postEvent("Play_DoorClose", gameObject);
		}

	}
	void Activate(){
		if(!m_isOpened)
			Open();
	}

}
