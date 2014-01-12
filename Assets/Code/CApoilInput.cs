using UnityEngine;
using System.Collections;

public struct SPlayerInput
{
	public bool MoveLeft;
	public bool MoveRight;
	public bool MoveForward;
	public bool MoveBackward;
	public bool InteractHand;
	public bool InteractHandDown;
	public bool InteractFer;
	public bool Jump;
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
		
		InputPlayer.InteractHand = Input.GetMouseButton(0);
		InputPlayer.InteractHandDown = Input.GetMouseButtonDown(0);
		InputPlayer.InteractFer = Input.GetMouseButton(1);

		InputPlayer.Jump = Input.GetKeyDown(KeyCode.Space);
		
		Quit = Input.GetKeyDown(KeyCode.Escape);
		Restart = Input.GetKeyDown(KeyCode.R);
		
		DebugF9 = Input.GetKeyDown(KeyCode.F9);
		DebugF10 = Input.GetKeyDown(KeyCode.F10);
		DebugF11 = Input.GetKeyDown(KeyCode.F11);
		DebugF12 = Input.GetKeyDown(KeyCode.F12);
	}	

}
