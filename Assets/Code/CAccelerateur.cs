using UnityEngine;
using System.Collections;

public class CAccelerateur : MonoBehaviour {

	bool m_isOpened = false;
	bool m_bLaunchEnd;
	public GameObject m_Game;
	
	public float m_fLife;
	bool m_bRepaired = false;

	// Use this for initialization
	void Start () {
		m_bLaunchEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!m_bRepaired && !m_Game.GetComponent<CGame>().m_bWin)
			m_fLife -= Time.deltaTime;
		if(m_fLife < 0 && !m_bLaunchEnd)
		{
			m_Game.GetComponent<CGame>().EndGame(false);
			m_bLaunchEnd = true;
		}
	}

	void OnGUI()
	{
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.font = m_Game.GetComponent<CGame>().m_Font; 
		GUI.Label(new Rect( 20, 90, 1000, 100),"Remaining time : "+m_fLife.ToString(),centeredStyle);
	}

	public void Open()
	{
		animation.PlayQueued("Ouverture");
		m_isOpened = true;
		m_Game.GetComponent<CGame>().GetSoundEngine().postEvent("Play_DoorOver", m_Game.gameObject);


	}

	void Repair(){
		m_bRepaired = true;
	}

	public void Close()
	{
		if(m_isOpened){
			animation.PlayQueued("Fermeture");
			m_isOpened = false;
			m_Game.GetComponent<CGame>().GetSoundEngine().postEvent("Play_DoorClose", m_Game.gameObject);
		}

	}
	void Activate(){
		if(!m_isOpened)
			Open();
	}

}
