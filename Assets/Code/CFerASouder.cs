using UnityEngine;
using System.Collections;

public class CFerASouder : MonoBehaviour 
{
	GameObject m_Etincelle;
	float m_fTimerEtincelle;
	const float m_fTimerEtincelleMax = 0.2f;
	CGame m_Game;
	bool m_bSoundLaunched;

	// Use this for initialization
	void Start () 
	{
		m_Etincelle = gameObject.transform.FindChild("Etincelles").gameObject;
		m_fTimerEtincelle = 0.0f;
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
		StopFire();
		m_bSoundLaunched = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_fTimerEtincelle > 0.0f)
		{
			m_fTimerEtincelle -= Time.deltaTime;	
		}
		else
		{
			StopFire();
		}
	}
	
	public void LaunchFire()
	{
		m_Etincelle.SetActiveRecursively(true);
		m_fTimerEtincelle = m_fTimerEtincelleMax;
		if(!m_bSoundLaunched)
		{
			m_Game.GetSoundEngine().postEvent("PlayFire", gameObject);
			m_bSoundLaunched = true;
		}
	}

	public void StopFire()
	{
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
		m_Game.GetSoundEngine().postEvent("StopFire", gameObject);
		m_bSoundLaunched = false;
	}
	
	
}
