using UnityEngine;
using System.Collections;

public class CAccelerateur : MonoBehaviour {

	bool m_isOpened = false;
	bool m_bLaunchEnd;
	public GameObject m_Game;
	CGame m_CGame;
	
	float m_fLife;
	bool m_bRepaired = false;

	public Texture m_TextureUse;
	public Texture m_TextureFond;

	// Use this for initialization
	void Start () {
		m_bLaunchEnd = false;
		m_CGame = GameObject.Find("_Game").GetComponent<CGame>();
		m_fLife = m_CGame.m_fTimerExplosion;
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

		int nPosX = (int)(m_CGame.m_fWidth) - 100;
		int nPosY = 20;
		
		float fHeightMax = 100.0f;
		float fHeight = fHeightMax * m_fLife / m_CGame.m_fTimerExplosion;
		GUI.DrawTexture(new Rect(nPosX, nPosY, 100, fHeightMax), m_TextureUse);
		GUI.DrawTexture(new Rect(nPosX, nPosY, 100, fHeightMax - fHeight), m_TextureFond);

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
