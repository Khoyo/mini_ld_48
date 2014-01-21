using UnityEngine;
using System.Collections;

public class CFirstMachine : MonoBehaviour {
			
	public Material mactive;
	bool m_bactive;
	float m_fTimerAffichage;
	const float m_fTimerAffichageMax = 3.0f;
	float m_fHeightText;
	CGame m_Game;
	
	// Use this for initialization
	void Start () {
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
		m_fTimerAffichage = 0.0f;
		m_fHeightText = m_Game.m_fHeightText;
		m_bactive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_fTimerAffichage > 0.0f && m_bactive)
			m_fTimerAffichage -= Time.deltaTime;
	}
	
	void Repair()
	{
		if(!m_bactive){
			renderer.material = mactive;
			m_bactive = true;
			m_fTimerAffichage = m_fTimerAffichageMax;
			m_Game.GetSoundEngine().postEvent("Play_FirstMachineRepair", gameObject);
		}
	}
	
	void OnGUI()
	{
		if(m_bactive)
		{
			
			GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			if(m_fTimerAffichage > 0.0f)
			{
				GUI.skin.label.font = m_Game.m_FontLarge; 
				GUI.Label(new Rect( 0, m_Game.m_fHeight - m_fHeightText, m_Game.m_fWidth, m_Game.m_fHeight), "Ok it’s repaire. Now I can push the button!", centeredStyle);
			}
		}
	}
		

}
