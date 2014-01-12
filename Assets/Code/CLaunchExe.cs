using UnityEngine;
using System.Collections;

using System.Diagnostics;
using System;

public class CLaunchExe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CApoilInput.DebugF9)
		{
			try
			{
				Process myProcess = new Process();
				myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				myProcess.StartInfo.CreateNoWindow = true;
				myProcess.StartInfo.UseShellExecute = false;
				myProcess.StartInfo.FileName = "C:\\Users\\tim-asus\\Data\\Projets de jeux\\Jeu_Ludum2013_Unity(5h)\\BlindBall_LeuhFahn\\BlindBall.exe";
				string path = "C:\\Users\\Brian\\Desktop\\testFile.bat";
				//myProcess.StartInfo.Arguments = "/c" + path;
				myProcess.EnableRaisingEvents = true;
				myProcess.Start();
				myProcess.WaitForExit();
				int ExitCode = myProcess.ExitCode;
				//print(ExitCode);
			} catch (Exception e){
				print(e);       
			}
		}
	}
}
