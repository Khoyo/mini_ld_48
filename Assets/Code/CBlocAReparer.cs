using UnityEngine;
using System.Collections;

public class CBlocAReparer : MonoBehaviour 
{

	bool m_isRepaired = false;
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
		if(repairCount != 0)
			m_isRepaired = true;
			print ("Repaired");
			m_gameObjectToActivate.SendMessage("Activate");
	}
}
