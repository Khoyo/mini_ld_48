﻿using UnityEngine;
using System.Collections;

public class CAccelerateur : MonoBehaviour {

	bool m_isOpened = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Open(){
			animation.PlayQueued("Ouverture");
			m_isOpened = true;
	}

	void Close()
	{
			animation.PlayQueued("Fermeture");
			m_isOpened = false;

	}
	void Activate(){
		if(m_isOpened)
			Close();
		else
			Open();
	}

}