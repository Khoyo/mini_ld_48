using UnityEngine;
using System.Collections;

public class CPlafond : MonoBehaviour {

	GameObject[] m_pSpot;
	float m_fVelocity = 5.0f;
	// Use this for initialization
	void Start () 
	{
		m_pSpot = GameObject.FindGameObjectsWithTag("SpotLight");

	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(GameObject currentLight in m_pSpot)
		{
			currentLight.transform.RotateAround(new Vector3(0,1,0), m_fVelocity * Time.deltaTime);
		}
	}
}
