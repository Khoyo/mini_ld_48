using UnityEngine;
using System.Collections;

public class CSol : MonoBehaviour {

	float m_fScale = 100.0f;

	// Use this for initialization
	void Start () 
	{
		float fWidth = gameObject.renderer.material.GetTexture("_MainTex").width;
		float fHeight = gameObject.renderer.material.GetTexture("_MainTex").height;
		float fX = gameObject.transform.localScale.x;
		float fY = gameObject.transform.localScale.z;
		
		gameObject.renderer.material.SetTextureScale("_MainTex", new Vector2(fX*m_fScale/ fWidth, fY*m_fScale/ fHeight));	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
