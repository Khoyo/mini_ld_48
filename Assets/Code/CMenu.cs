using UnityEngine;
using System.Collections;

public class CMenu : MonoBehaviour 
{

	public enum EmenuState
	{
		e_splash,
		e_main,
		e_Cinematique
	}
	
	float m_fWidth = 1280;
	float m_fHeight = 720;
	
	EmenuState m_EState;
	float m_fTempsSplash;
	float m_fTempsSplashInit = 2.0f;
	float m_fTempsVideoIntro;
	bool m_bLaunchGame;
	
	public Texture m_Texture_Fond;
	public Texture m_Texture_Splash;
	public MovieTexture m_Texture_Cinematique;

	
	// Use this for initialization
	void Start () 
	{
		m_fTempsSplash = m_fTempsSplashInit;
		m_EState = EmenuState.e_splash;
		m_fTempsVideoIntro = 0.0f;
		m_bLaunchGame = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_EState == EmenuState.e_splash && m_fTempsSplash>0.0f)
				m_fTempsSplash -= Time.deltaTime;
	}
	
	void OnGUI() 
	{
		switch(m_EState)
		{
			case EmenuState.e_splash:
			{
				if(m_fTempsSplash > 0.0f)
				{
					float fCoeffScale = 1.0f + (m_fTempsSplashInit - m_fTempsSplash)/(10.0f*m_fTempsSplashInit);
					float fWidth = m_fWidth * fCoeffScale;
					float fHeight = m_fHeight * fCoeffScale;
					GUI.DrawTexture(new Rect((m_fWidth - fWidth)/2.0f, (m_fHeight - fHeight)/2.0f, fWidth, fHeight), m_Texture_Splash);
				}
				else
					m_EState = EmenuState.e_main;
				break;
			}	
			
			case EmenuState.e_main:
			{
				GUI.DrawTexture(new Rect(0, 0, m_fWidth, m_fHeight), m_Texture_Fond);
				if(Input.GetKeyDown(KeyCode.Space))
					m_EState = EmenuState.e_Cinematique;
				break;
			}
			case EmenuState.e_Cinematique:
			{
				GUI.DrawTexture(new Rect(0, 0, 1280, 800), m_Texture_Cinematique);
				if(m_fTempsVideoIntro == 0.0f)
					m_Texture_Cinematique.Play();
				if(m_Texture_Cinematique.isPlaying)
				{
					m_fTempsVideoIntro += Time.deltaTime;
					if(Input.GetKeyDown(KeyCode.Space) && m_fTempsVideoIntro>0.5f)
						m_Texture_Cinematique.Stop ();
				}
				else if(!m_bLaunchGame)
				{
					Application.LoadLevel(Application.loadedLevel+1);
					m_bLaunchGame = true;
				}
				
				break;
			}
		}
	}
}
