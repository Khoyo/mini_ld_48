﻿using UnityEngine;
using System.Collections;

public class CRecharge : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<CPlayer>().ReloadWeapon();
			Object.Destroy(gameObject);
		}

	}
}
