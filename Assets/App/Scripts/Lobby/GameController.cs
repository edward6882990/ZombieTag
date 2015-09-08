using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  protected SocketIOComponent socket;
  protected GamePanel gamePanel;
  protected LobbyPanel lobbyPanel;

  void Start(){
    gamePanel  = GameObject.Find("GamePanel").GetComponent<GamePanel>();
    lobbyPanel = GameObject.Find("LobbyPanel").GetComponent<LobbyPanel>();
    socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();

    socket.On("create:gameroom:success", OnCreateGameRoomSuccess);
  }


  void ShowGamePanel(){
    gamePanel.GetComponent<Renderer>().enabled = true;
  }

  void HideGamePanel(){
    gamePanel.GetComponent<Renderer>().enabled = false;    
  }

  void ShowLobbyPanel(){
    lobbyPanel.GetComponent<Renderer>().enabled = true;
  }

  void HideLobbyPanel(){
    lobbyPanel.GetComponent<Renderer>().enabled = false;
  }

  public void OnClickCreateGameButton(){
    Dictionary<string, string> data = new Dictionary<string, string>();
    data["type"] = "private";
    socket.Emit("create:gameroom", new JSONObject(data));
  }

  void OnCreateGameRoomSuccess(SocketIOEvent ev){
    HideLobbyPanel();
    ShowGamePanel();
  }

  void OnDestroy(){
    socket.Off("create:gameroom:success", OnCreateGameRoomSuccess);
  }
}