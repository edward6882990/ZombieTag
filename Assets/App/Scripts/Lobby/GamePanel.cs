using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class GamePanel : MonoBehaviour {

    protected bool isInitialized = false;

    void Start(){
      Events.onCreateGameRoomSuccess += UpdatePlayersDisplayView;
      Events.onJoinGameRoomSuccess += UpdatePlayersDisplayView;
      Events.onLeftGameRoom += LeftGameRoom;
      Hide();
    }

    void OnDestroy(){
      Events.onCreateGameRoomSuccess -= UpdatePlayersDisplayView;
      Events.onJoinGameRoomSuccess -= UpdatePlayersDisplayView;
      Events.onLeftGameRoom -= LeftGameRoom;
    }

    void UpdatePlayersDisplayView(SocketIOEvent ev){
      JSONObject players = ev.data["players"];

      transform.Find("PlayersDisplay")
        .GetComponent<PlayersDisplay>()
        .UpdatePlayersView(players);

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
