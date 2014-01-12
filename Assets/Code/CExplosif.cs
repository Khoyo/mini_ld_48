using UnityEngine;
using System.Collections;

public class CExplosif : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ArmExplosion()
	{
		gameObject.SetActiveRecursively(false);
		gameObject.active = true;
	}

	public void Explode()
	{
		gameObject.SetActiveRecursively(true);
	}
}
