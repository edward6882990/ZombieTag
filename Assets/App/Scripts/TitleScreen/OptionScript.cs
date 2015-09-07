using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class OptionScript : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load ("OptionGUISkin") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		GUI.skin = skin;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Option"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			print ("Load Application Level Game Option");
			//Application.LoadLevel("Stage1");
		}
	}
}