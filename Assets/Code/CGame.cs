using UnityEngine;
using System.Collections;

public class CGame : MonoBehaviour 
{
	 
	// Use this for initialization
	void Start () 
	{
		CApoilInput.Init();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CApoilInput.Process(Time.deltaTime);
		
		if(CApoilInput.Quit)
			Application.Quit();
	}
}
