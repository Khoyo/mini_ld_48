using UnityEngine;
using System.Collections;

public struct SPlayerInput
{
	public bool MoveLeft;
	public bool MoveRight;
	public bool MoveForward;
	public bool MoveBackward;
	public float MouseAngleX;
	public float MouseAngleY;
}

public class CApoilInput
{
	public static SPlayerInput InputPlayer;
	
	public static bool Quit;
	public static bool Restart;
	
	//Debug
	public static bool DebugF9;
	public static bool DebugF10;
	public static bool DebugF11;
	public static bool DebugF12;
	
	
	public static void Init()
	{
		//Screen.lockCursor = true;
	}
	
	//-------------------------------------------------------------------------------
	///
	//-------------------------------------------------------------------------------
	public static void Process(float fDeltatime) 
	{	
		InputPlayer.MoveForward = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow);
		InputPlayer.MoveBackward = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
		InputPlayer.MoveLeft = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow);
		InputPlayer.MoveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);		
		
		InputPlayer.MouseAngleX = Input.GetAxis("Mouse X");
		InputPlayer.MouseAngleY = -Input.GetAxis("Mouse Y");
		
		Quit = Input.GetKeyDown(KeyCode.Escape);
		Restart = Input.GetKeyDown(KeyCode.R);
		
		DebugF9 = Input.GetKeyDown(KeyCode.F9);
		DebugF10 = Input.GetKeyDown(KeyCode.F10);
		DebugF11 = Input.GetKeyDown(KeyCode.F11);
		DebugF12 = Input.GetKeyDown(KeyCode.F12);
	}	
	
	/*
	//-------------------------------------------------------------------------------
	///
	//-------------------------------------------------------------------------------	
	public static Vector2 CalculateMousePosition()
	{
		
		Vector3 posMouseTmp = Vector3.zero;
		RaycastHit vHit = new RaycastHit();
		Ray vRay = m_Game.m_CameraCone.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(vRay, out vHit, 100)) 
		{
			posMouseTmp = vHit.point;
		}
		return new Vector2(posMouseTmp.x, posMouseTmp.y);
	}
	*/
}
