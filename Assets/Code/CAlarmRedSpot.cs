using UnityEngine;
using System.Collections;

public class CAlarmRedSpot : MonoBehaviour {

	bool m_bActive;
	float m_fVelocity = 5.0f;

	// Use this for initialization
	void Start () 
	{
		m_bActive = false;
		transform.RotateAround(new Vector3(0,1,0), gameObject.GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.RotateAround(new Vector3(0,1,0),m_fVelocity * Time.deltaTime);
	}

	public void ActivateSpot()
	{
		m_bActive = true;
		GameObject.Find("_Game").GetComponent<CGame>().GetSoundEngine().postEvent("Play_AmbianceAlarme", gameObject);
	}

	public void DesactivateSpot()
	{
		m_bActive = false;
		GameObject.Find("_Game").GetComponent<CGame>().GetSoundEngine().postEvent("Stop_AmbianceAlarme", gameObject);
	}
}
