using UnityEngine;
using System.Collections;

public class CTriggerSortieBureau : MonoBehaviour {

	bool m_bIsActivated;
	CGame m_Game;
	float m_fTimerAffichage;
	const float m_fTimerAffichageMax = 5.0f;
	float m_fHeightText;

	// Use this for initialization
	void Start () 
	{
		m_bIsActivated = false;
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
		m_fTimerAffichage = 0.0f;
		m_fHeightText = m_Game.m_fHeightText;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_fTimerAffichage > 0.0f)
			m_fTimerAffichage -= Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(!m_bIsActivated)
				OutOfBureau();
		}
	}

	void OutOfBureau()
	{
		m_bIsActivated = true;
		m_fTimerAffichage = m_fTimerAffichageMax;
		m_Game.GetSoundEngine().postEvent("Play_TriggerSortieBureau", gameObject);
	}

	void OnGUI()
	{

		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		if(m_fTimerAffichage > 0.0f)
		{
			GUI.skin.label.font = m_Game.m_FontLarge; 
			GUI.Label(new Rect( 0, m_Game.m_fHeight - m_fHeightText, m_Game.m_fWidth, m_Game.m_fHeight), "Ho Shit, I gotta go to the Particle Accelerator!", centeredStyle);
		}
	}
}
