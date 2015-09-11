using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour {
	public void LoadGameScene(){
		Application.LoadLevel("Game");
	}
}