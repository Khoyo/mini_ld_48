using UnityEngine;
using System.Collections;

public class CGame : MonoBehaviour 
{
	string soundbankName = "Ludum48_SoundBank.bnk";
	CSoundEngine m_SoundEngine;

	// Use this for initialization
	void Start () 
	{
		CApoilInput.Init();

		m_SoundEngine = new CSoundEngine();
		m_SoundEngine.Init();
		m_SoundEngine.LoadBank(soundbankName);
	}
	
	// Update is called once per frame
	void Update ()
	{
		CApoilInput.Process(Time.deltaTime);
		
		if(CApoilInput.Quit)
			Application.Quit();
	}

	public CSoundEngine GetSoundEngine()
	{
		return m_SoundEngine;
	}
}
