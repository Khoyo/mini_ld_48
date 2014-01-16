using UnityEngine;
using System.Collections;

public class CPlafond : MonoBehaviour {

	GameObject[] m_pSpot;
	// Use this for initialization
	void Start () 
	{
		m_pSpot = GameObject.FindGameObjectsWithTag("SpotLight");
		ActivateSpot();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void ActivateSpot()
	{
		foreach(GameObject currentLight in m_pSpot)
		{
			currentLight.GetComponent<CAlarmRedSpot>().ActivateSpot();
		}
	}
	
	public void DesactivateSpot()
	{
		foreach(GameObject currentLight in m_pSpot)
		{
			currentLight.GetComponent<CAlarmRedSpot>().DesactivateSpot();
		}
	}
}
