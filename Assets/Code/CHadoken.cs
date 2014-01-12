using UnityEngine;
using System.Collections;

public class CHadoken : MonoBehaviour {

	public GameObject m_far, m_near, m_hadoken;
	public int m_force = 50;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(CApoilInput.InputPlayer.InteractHandDown)
		{
			GameObject hado = (GameObject) Instantiate(m_hadoken);
			hado.transform.position = m_far.transform.position;
			hado.rigidbody.AddForce(m_force * (m_far.transform.position - m_near.transform.position).normalized);
		}

	}
}
