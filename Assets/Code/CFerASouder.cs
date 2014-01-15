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
	bool lost;

	public bool WasInThisFrame = true;
	public bool WasSolderThisFrame = true;

	// Use this for initialization
	void Start () 
	{
		m_Etincelle = gameObject.transform.FindChild("Etincelles").gameObject;
		m_fTimerEtincelle = 0.0f;
		m_Game = GameObject.Find("_Game").GetComponent<CGame>();
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
		m_bSoundLaunched = false;
		m_Game.GetSoundEngine().setSwitch("Soudure","Aire", gameObject);
		lost = false;
		m_fSoudureRestante = m_Game.m_fQuantiteSoudureDepart;
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

	void FixedUpdate(){
		if(!WasInThisFrame)
		{
				m_Game.GetSoundEngine().setSwitch("Soudure","Aire", gameObject);
		}
		else
		{
			if(WasSolderThisFrame)
				m_Game.GetSoundEngine().setSwitch("Soudure","OK", gameObject);
			else
				m_Game.GetSoundEngine().setSwitch("Soudure","Erreur", gameObject);
		}
		WasInThisFrame = false;
		WasSolderThisFrame = false;
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

	void OnGUI()
	{
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperLeft;
		GUI.skin.label.font = m_Game.m_Font; 
		GUI.Label(new Rect( 20, 20, 1000, 100),"Remaining solder : "+m_fSoudureRestante.ToString(),centeredStyle);
	}

	public void StopFire()
	{
		m_Etincelle.SetActiveRecursively(false);
		m_Etincelle.active = true;
		m_Game.GetSoundEngine().postEvent("Stop_Soudure", gameObject);
		m_bSoundLaunched = false;
	}

	public void OnTriggerStay(Collider other)
	{
		WasInThisFrame = true;
		if(other.CompareTag("Fissure"))
		{
			WasSolderThisFrame = true;
		}
	}

<<<<<<< HEAD
	public void Reload()
	{
		m_fSoudureRestante += m_Game.m_fQuantiteSoudureReload;
		GameObject.Find("_Game").GetComponent<CGame>().GetSoundEngine().postEvent("Play_ReloadWeapon", gameObject);
	}

=======
	public void OnCollisionStay(Collision other)
	{
		WasInThisFrame = true;
		
	}



>>>>>>> e71219f7e28edfc9095c767ffaeb944191aea856
	
}
