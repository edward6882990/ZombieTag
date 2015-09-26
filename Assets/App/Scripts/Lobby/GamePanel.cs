using UnityEngine;
using SocketIO;
using System.Collections;

namespace Lobby {
  public class GamePanel : MonoBehaviour {

    protected bool isInitialized = false;

    void Start(){
      Events.onCreateGameRoomSuccess += GameRoomCreated;
      Events.onLeftGameRoom += LeftGameRoom;
      Hide();
    }

    void OnDestroy(){
      Events.onCreateGameRoomSuccess -= GameRoomCreated;
      Events.onLeftGameRoom -= LeftGameRoom;
    }

    void GameRoomCreated(SocketIOEvent ev){
      Show();
    }

    void LeftGameRoom(SocketIOEvent ev){
      Hide();
    }

    public void Show(){
      transform.gameObject.active = true;
    }

    public void Hide(){
      transform.gameObject.active = false;    

      Events.GamePanelClosed();
    }

  }
}
