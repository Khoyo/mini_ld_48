using UnityEngine;
using System.Collections;

public class CRecharge : MonoBehaviour 
{
	Vector3 posInit;
	// Use this for initialization
	void Start () 
	{
		posInit = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPos = posInit + new Vector3(0, Mathf.Cos(Time.deltaTime), 0);
		gameObject.transform.position = newPos;
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
