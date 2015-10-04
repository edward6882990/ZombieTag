using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TitleScreen;


namespace TitleScreen {
  public class StartButton : MonoBehaviour {
    public void LoadGameScene(){
      Application.LoadLevel("Game");
    }
  }
}
