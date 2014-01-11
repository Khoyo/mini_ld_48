using UnityEngine;
using System.Collections;

public class CFerASouder : MonoBehaviour 
{
	GameObject m_Etincelle;
	float m_fTimerEtincelle;
	const float m_fTimerEtincelleMax = 0.2f;
	// Use this for initialization
	void Start () 
	{
		m_Etincelle = gameObject.transform.FindChild("Etincelles").gameObject;
		m_fTimerEtincelle = 0.0f;
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
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
			m_Etincelle.SetActiveRecursively(false);
			m_Etincelle.active = true;
		}
	}
	
	public void LaunchFire()
	{
		m_Etincelle.SetActiveRecursively(true);
		m_fTimerEtincelle = m_fTimerEtincelleMax;
	}
	
	
}
