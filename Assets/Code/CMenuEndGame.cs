using UnityEngine;
using System.Collections;

public class CMenuEndGame : MonoBehaviour {

	float m_fWidth = 1280;
	float m_fHeight = 720;

	float m_fTempsVideoIntro;
	bool m_bStart;
	bool m_bLaunchGame;
	public MovieTexture m_Texture_Cinematique;

	// Use this for initialization
	void Start () 
	{
		m_fTempsVideoIntro = 0.0f;
		m_bStart = false;
		m_bLaunchGame = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void StartMenu()
	{
		m_bStart = true;
	}

	void OnGUI()
	{
		if(m_bStart)
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
				Application.LoadLevel(0);
				m_bLaunchGame = true;
			}
		}
	}
}
