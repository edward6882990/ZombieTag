using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SocketIOComponent))]
public class Events : MonoBehaviour {

  // ================= Socket Events =====================

  public delegate void SocketEventHandler(SocketIOEvent ev);
  public static event SocketEventHandler onCreateGameRoomSuccess;
  public static event SocketEventHandler onJoinGameRoomSuccess;
  public static event SocketEventHandler onGameRoomUpdated;
  public static event SocketEventHandler onLeftGameRoom;
  public static event SocketEventHandler onReceivedLobbyUpdate;
  public static event SocketEventHandler onLobbyUpdated;
  public static event SocketEventHandler onLoadGame;

  public static void GameRoomCreated(SocketIOEvent ev){
    if (onCreateGameRoomSuccess != null) onCreateGameRoomSuccess(ev);
  }

  public static void GameRoomJoined(SocketIOEvent ev){
    if (onJoinGameRoomSuccess != null) onJoinGameRoomSuccess(ev);
  }

  public static void GameRoomUpdated(SocketIOEvent ev){
    if (onGameRoomUpdated != null) onGameRoomUpdated(ev);
  }

  public static void LeftGameRoom(SocketIOEvent ev){
    if (onLeftGameRoom != null) onLeftGameRoom(ev);
  }
  
  public static void ReceivedLobbyUpdate(SocketIOEvent ev){
    if (onReceivedLobbyUpdate != null) onReceivedLobbyUpdate(ev);
  }

  public static void LobbyUpdated(SocketIOEvent ev){
    if (onLobbyUpdated != null)  onLobbyUpdated(ev);
  }

  public static void LoadGame(SocketIOEvent ev){
    if (onLoadGame != null) onLoadGame(ev);
  }


  //================== Lobby Events ==================

  public delegate void LobbyEventHandler();
  public static event LobbyEventHandler onCloseGamePanel;

  public static void GamePanelClosed(){
    if (onCloseGamePanel != null)  onCloseGamePanel();
  }

  public static void GetLobbyUpdate(SocketIOComponent socket, int pageNum){
    Dictionary<string, string> data = new Dictionary<string, string>();
    data["page"] = pageNum.ToString();
    socket.Emit("lobby:get-update", new JSONObject(data)); 
  }

  protected SocketIOComponent socket;

  void Start(){
    socket = GetComponent<SocketIOComponent>();

    socket.On("create:gameroom:success", GameRoomCreated);
    socket.On("join:gameroom:success", GameRoomJoined);
    socket.On("left:gameroom", LeftGameRoom);
    socket.On("lobby:updated", LobbyUpdated);
    socket.On("gameroom:updated", GameRoomUpdated);
    socket.On("lobby:receive-update", ReceivedLobbyUpdate);
    socket.On("game:load", LoadGame);

    Application.LoadLevel("Lobby");
  }
}
