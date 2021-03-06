using UnityEngine;
using System.Collections;

public class CGame : MonoBehaviour 
{
	string soundbankName = "Ludum48_SoundBank.bnk";

	CSoundEngine m_SoundEngine;

	GameObject[] m_pTrucAReparer;
	GameObject[] m_pExplosifs;
	int m_nNbReparation;

	public Font m_FontLarge;
	public Font m_FontSmall;

	public float m_fWidth = 1280;
	public float m_fHeight = 720;
	public float m_fHeightText = 100;

	public bool m_bInGame;
	public bool m_bWin;

	public float m_fTimerExplosion = 200.0f;
	public float m_fQuantiteSoudureDepart = 200.0f;
	public float m_fQuantiteSoudureReload = 10.0f;

	// Use this for initialization
	void Start () 
	{
		CApoilInput.Init();

		m_SoundEngine = new CSoundEngine();
		m_SoundEngine.Init();
		m_SoundEngine.LoadBank(soundbankName);

		m_bInGame = true;
		m_bWin = false;

		m_nNbReparation = 0;
		m_pTrucAReparer = GameObject.FindGameObjectsWithTag("TrucAReparer");
		foreach(GameObject current in m_pTrucAReparer)
			m_nNbReparation++;

		m_SoundEngine.postEvent("Play_AmbianceLabo_01", gameObject);

		m_pExplosifs = GameObject.FindGameObjectsWithTag("Explosif");
		foreach(GameObject currentExplosif in m_pExplosifs)
		{
			currentExplosif.GetComponent<CExplosif>().ArmExplosion();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		CApoilInput.Process(Time.deltaTime);
		
		if(CApoilInput.Quit)
			Application.Quit();

		if(m_bInGame)
		{
			if(m_nNbReparation == 0)
				EndGame(true);
		}
	}

	public void EndGame(bool bWin)
	{
		if(bWin)
		{
			Debug.Log ("YOU WIN!!");

		}
		else
		{
			Debug.Log ("YOU LOSE!!");
			DestroyTheWorld();
		}

		m_SoundEngine.postEvent("Stop_AmbianceLabo_01", gameObject);
		m_SoundEngine.postEvent("Stop_AmbianceAlarme", gameObject);
		m_bWin = bWin;
		m_bInGame = false;
	}

	void DestroyTheWorld()
	{
		GameObject[] pExplosifs = GameObject.FindGameObjectsWithTag("Explosif");
		foreach(GameObject currentExplosif in pExplosifs)
		{
			currentExplosif.GetComponent<CExplosif>().Explode();
		}
		m_SoundEngine.postEvent("Play_ExploFin", gameObject);

	}

	public CSoundEngine GetSoundEngine()
	{
		return m_SoundEngine;
	}

	void Activate()
	{
		m_nNbReparation--;
	}
}
