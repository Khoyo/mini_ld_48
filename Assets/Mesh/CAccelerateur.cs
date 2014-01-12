using UnityEngine;
using System.Collections;

public class CAccelerateur : MonoBehaviour {

	bool m_isOpened = false;
	CGame m_Game;

	// Use this for initialization
	void Start ()
	{
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Open(){
		animation.PlayQueued("Ouverture");
		m_isOpened = true;
		m_Game.GetSoundEngine().postEvent("Play_DoorOver", gameObject);
	}

	public void Close()
	{
		if(m_isOpened){
			animation.PlayQueued("Fermeture");
			m_isOpened = false;
			m_Game.GetSoundEngine().postEvent("Play_DoorClose", gameObject);
		}

	}
	void Activate(){
		if(!m_isOpened)
			Open();
	}

}
