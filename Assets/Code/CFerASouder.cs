using UnityEngine;
using System.Collections;

public class CFerASouder : MonoBehaviour 
{
	GameObject m_Etincelle;
	float m_fTimerEtincelle;
	const float m_fTimerEtincelleMax = 0.2f;
	float m_fSoudureRestante;
	CGame m_Game;
	bool m_bSoundLaunched;
	bool lost = false;

	// Use this for initialization
	void Start () 
	{
		m_fSoudureRestante = 20;

		m_Etincelle = gameObject.transform.FindChild("Etincelles").gameObject;
		m_fTimerEtincelle = 0.0f;
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
		m_bSoundLaunched = false;
		m_Game.GetSoundEngine().setSwitch("Soudure","Aire", gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_fTimerEtincelle > 0.0f)
		{
			m_fTimerEtincelle -= Time.deltaTime;	
		}
		else if(m_bSoundLaunched)
		{
			StopFire();
		}

		if(CApoilInput.InputPlayer.InteractFer)
			m_fSoudureRestante -= Time.deltaTime;

		if(m_fSoudureRestante < 0 && !lost)
		{
			m_Game.EndGame(false);
			lost = true;
		}
	}
	
	public void LaunchFire()
	{
		m_Etincelle.SetActiveRecursively(true);
		m_fTimerEtincelle = m_fTimerEtincelleMax;
		if(!m_bSoundLaunched)
		{

			m_Game.GetSoundEngine().postEvent("Play_Soudure", gameObject);

			m_bSoundLaunched = true;
		}
	}

	public void StopFire()
	{
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
		m_Game.GetSoundEngine().postEvent("Stop_Soudure", gameObject);
		m_bSoundLaunched = false;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Fissure"))
		{
			m_Game.GetSoundEngine().setSwitch("Soudure","OK", gameObject);
		}
	}

	
}
