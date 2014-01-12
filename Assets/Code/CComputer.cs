using UnityEngine;
using System.Collections;

public class CComputer : MonoBehaviour 
{
	GameObject m_BlackScreen;
	bool m_bOn;
	float m_fTimerWait;
	const float m_fTimerWaitMax = 0.5f;
	// Use this for initialization
	void Start () 
	{
		m_BlackScreen = gameObject.transform.FindChild("BlackScreen").gameObject;
		m_BlackScreen.SetActive(false);
		m_bOn = true;
		m_fTimerWait = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_fTimerWait >= 0.0f)
			m_fTimerWait -= Time.deltaTime;
	}

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Hand") && CApoilInput.InputPlayer.InteractHand && m_fTimerWait < 0.0f)
		{
			if(m_bOn)
			{
				m_BlackScreen.SetActive(true);
				m_bOn = false;
				m_fTimerWait = m_fTimerWaitMax;
			}
			else
			{
				m_BlackScreen.SetActive(false);
				m_bOn = true;
				m_fTimerWait = m_fTimerWaitMax;
			}
		}

	}
}
