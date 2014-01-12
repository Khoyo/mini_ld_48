using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour 
{

	enum Estate
	{
		e_Start,
		e_normal,
		e_end_win,
		e_end_lose
	}

	Estate m_eState;
	float m_fVelocityWalk = 10.0f;
	float m_fVelocityRotation = 0.5f;
	float m_fVelocityJump = 250.0f;
	float m_fAngleY;
	float m_fTimerJump;
	float m_fTimerJumpMax = 1.0f;
	float m_fTimerWakeUp;
	float m_fTimerWakeUpMax = 2.0f;
	float m_fCompter;
	float m_fAngleWake;
	CFerASouder m_Fer;
	CHand m_Hand;

	
	// Use this for initialization
	void Start () 
	{
		m_fAngleY = 0.0f;
		m_fAngleWake = 0.0f;
		m_Fer = gameObject.transform.FindChild("MainCamera").FindChild("Fer").GetComponent<CFerASouder>();
		m_Hand = gameObject.transform.FindChild("MainCamera").FindChild("Hand").GetComponent<CHand>();
		m_fTimerJump = 0.0f;
		m_fTimerWakeUp = 0.0f;
		m_eState = Estate.e_Start;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_fTimerJump >= 0.0f)
			m_fTimerJump -= Time.deltaTime;
		InputsPlayer();

		switch(m_eState)
		{
			case Estate.e_Start:
			{
				if(m_fTimerWakeUp < m_fTimerWakeUpMax)
				{
					m_fTimerWakeUp += Time.deltaTime;
					m_fCompter += 1;
					float fAngleBefore = m_fAngleWake;
					m_fAngleWake = CApoilMath.InterpolationLinear(m_fTimerWakeUp, 0.0f, m_fTimerWakeUpMax, 0.0f, 90.0f);
					float fAngleRad = CApoilMath.ConvertDegreeToRadian(m_fAngleWake - fAngleBefore);
					gameObject.transform.RotateAround(new Vector3(0,0,1), -fAngleRad);			
				}
				else
				{
					m_eState = Estate.e_normal;
				}
				break;
			}
			case Estate.e_normal:
			{
				Move();
				MoveHead();
				break;
			}
			case Estate.e_end_win:
			{
				break;
			}
		}


	}
	
	void Move()
	{
		float fAngleX = gameObject.transform.rotation.eulerAngles.y * 2*3.14f/360.0f;
		Vector3 vForward = new Vector3(Mathf.Sin(fAngleX),0, Mathf.Cos(fAngleX));
		Vector3 vRight = new Vector3(Mathf.Sin(fAngleX + 3.14f/2.0f),0, Mathf.Cos(fAngleX + 3.14f/2.0f));
		Vector3 vUp = new Vector3(0,1,0);
		
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

		if(CApoilInput.InputPlayer.Jump && m_fTimerJump < 0.0f)
		{
			gameObject.rigidbody.AddForce(m_fVelocityJump*vUp);
			m_fTimerJump = m_fTimerJumpMax;
		}
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

	void InputsPlayer()
	{
		if(CApoilInput.InputPlayer.InteractFer)
		{
			m_Fer.LaunchFire();	
		}
	}
}
