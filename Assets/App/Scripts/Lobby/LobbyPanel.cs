using UnityEngine;
using SocketIO;
using System.Collections;

namespace Lobby {
  public class LobbyPanel : MonoBehaviour {

    void OnEnable(){
      Events.onCreateGameRoomSuccess += GameRoomCreated;
      Events.onJoinGameRoomSuccess += GameRoomJoined;
      Events.onCloseGamePanel += Show;
    }

    void OnDisable(){
      Events.onCreateGameRoomSuccess -= GameRoomCreated;
    }

    void OnDestroy(){
      Events.onCreateGameRoomSuccess -= GameRoomCreated;
      Events.onCloseGamePanel -= Show;
    }

    void GameRoomCreated(SocketIOEvent ev){
      Hide();
    }

    void GameRoomJoined(SocketIOEvent ev){
      Hide();
    }

    public void Show(){
      transform.gameObject.active = true;
    }

    public void Hide(){
      transform.gameObject.active = false;    
    }

  }
}
