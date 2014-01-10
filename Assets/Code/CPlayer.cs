using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {

	float m_fVelocityWalk = 10.0f;
	float m_fVelocityRotation = 0.5f;
	float m_fAngleY;
	
	// Use this for initialization
	void Start () 
	{
		m_fAngleY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		MoveHead();
	}
	
	void Move()
	{
		float fAngleX = gameObject.transform.rotation.eulerAngles.y * 2*3.14f/360.0f;
		Vector3 vForward = new Vector3(Mathf.Sin(fAngleX),0, Mathf.Cos(fAngleX));
		Vector3 vRight = new Vector3(Mathf.Sin(fAngleX + 3.14f/2.0f),0, Mathf.Cos(fAngleX + 3.14f/2.0f));
		
		if(CApoilInput.InputPlayer.MoveForward)
			gameObject.rigidbody.AddForce(m_fVelocityWalk*vForward);
		if(CApoilInput.InputPlayer.MoveBackward)
			gameObject.rigidbody.AddForce(-m_fVelocityWalk*vForward);
		if(CApoilInput.InputPlayer.MoveLeft)
			gameObject.rigidbody.AddForce(-m_fVelocityWalk*vRight);
		if(CApoilInput.InputPlayer.MoveRight)
			gameObject.rigidbody.AddForce(m_fVelocityWalk*vRight);
		if(!CApoilInput.InputPlayer.MoveForward && !CApoilInput.InputPlayer.MoveBackward && !CApoilInput.InputPlayer.MoveLeft && !CApoilInput.InputPlayer.MoveRight)
		{
			Vector3 vel = gameObject.rigidbody.velocity;
			vel.x *= 0.85f;
			vel.z *= 0.85f;
			gameObject.rigidbody.velocity = vel;
		}
		
		gameObject.transform.RotateAround(new Vector3(0,1,0),m_fVelocityRotation * CApoilInput.InputPlayer.MouseAngleX);	
	}
	
	void MoveHead()
	{
		float fAngleMax = -1.5f;
		float fAngleMin = 1.5f;
		float fAngleBeforeY = m_fAngleY;
		
		m_fAngleY += CApoilInput.InputPlayer.MouseAngleY;

		if(m_fAngleY < fAngleMax)
			m_fAngleY = fAngleMax;
		else if(m_fAngleY > fAngleMin)
			m_fAngleY = fAngleMin;
		
		gameObject.transform.FindChild("MainCamera").RotateAroundLocal(new Vector3(1,0,0), m_fVelocityRotation * (m_fAngleY - fAngleBeforeY));
	}

}
