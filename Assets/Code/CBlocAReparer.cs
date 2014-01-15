using UnityEngine;
using System.Collections;

public class CBlocAReparer : MonoBehaviour 
{

	public bool m_isRepaired = false;
	int repairCount;
	public GameObject m_gameObjectToActivate;
	
	// Use this for initialization
	void Start () 
	{
		repairCount = GetComponentsInChildren<CFissure>().Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Repair() 
	{
		if(--repairCount != 0)
			return;
		m_isRepaired = true;
		print ("Repaired");
		if(m_gameObjectToActivate != null)
			m_gameObjectToActivate.SendMessage("Activate");
		else
			Debug.Log ("Warning : Game object "+gameObject.name+" have no game object to activate");
	}
}
