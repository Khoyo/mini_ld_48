using UnityEngine;
using System.Collections;

public class TestHandMove : MonoBehaviour 
{

	float m_fTimerAnimHand;
	float m_fTimerAnimHandMax = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CApoilInput.InputPlayer.InteractHand && m_fTimerAnimHand <= 0.0f)
		{
			m_fTimerAnimHand = m_fTimerAnimHandMax;
		}
		
		if(m_fTimerAnimHand > 0.0f)
		{
			float fAngle = CApoilMath.InterpolationLinear(m_fTimerAnimHand, 0.0f, m_fTimerAnimHandMax, 0, 3.14159f);
			float fTranslation = Mathf.Cos(fAngle);
			Debug.Log (fTranslation);
			
			//gameObject.transform.FindChild("MainCamera").FindChild("Hand").FindChild("Mesh").transform.Translate(fTranslation/100 * m_vForward.normalized);
			//Vector3 vForward = gameObject.transform.FindChild("MainCamera");
			
			gameObject.transform.Translate(fTranslation/8 * Vector3.down);
			/*
			Vector3 vPos = gameObject.transform.FindChild("MainCamera").FindChild("Hand").transform.position;
			vPos.z += -fTranslation/100;
			gameObject.transform.FindChild("MainCamera").FindChild("Hand").transform.position = vPos;
*/
			m_fTimerAnimHand -= Time.deltaTime;
			
		}
	}
}
