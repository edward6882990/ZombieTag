using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LobbyPlayer : NetworkLobbyPlayer {
  public virtual void OnClientEnterLobby(){
  }

  public virtual void OnClientExitLobby(){
  }

  public virtual void OnClientReady(bool readyState){
  }

}
