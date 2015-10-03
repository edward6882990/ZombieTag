using UnityEngine;
using SocketIO;
using System.Collections;

[RequireComponent(typeof(SocketIOComponent))]
public class Events : MonoBehaviour {

  // ================= Socket Events =====================

  public delegate void SocketEventHandler(SocketIOEvent ev);
  public static event SocketEventHandler onCreateGameRoomSuccess;
  public static event SocketEventHandler onJoinGameRoomSuccess;
  public static event SocketEventHandler onLeftGameRoom;
  public static event SocketEventHandler onGameRoomReceiveUpdates;
  public static event SocketEventHandler onGameRoomsUpdated;
  public static event SocketEventHandler onPlayerJoinedGameRoom;
  public static event SocketEventHandler onPlayerLeftGameRoom;
  public static event SocketEventHandler onLoadGame;

  public static void GameRoomCreated(SocketIOEvent ev){
    if (onCreateGameRoomSuccess != null) onCreateGameRoomSuccess(ev);
  }

  public static void GameRoomJoined(SocketIOEvent ev){
    if (onJoinGameRoomSuccess != null) onJoinGameRoomSuccess(ev);
  }

  public static void LeftGameRoom(SocketIOEvent ev){
    if (onLeftGameRoom != null) onLeftGameRoom(ev);
  }
  
  public static void ReceivedGameRoomsUpdate(SocketIOEvent ev){
    if (onGameRoomReceiveUpdates != null) onGameRoomReceiveUpdates(ev);
  }

  public static void GameRoomsUpdated(SocketIOEvent ev){
    if (onGameRoomsUpdated != null)  onGameRoomsUpdated(ev);
  }

  public static void PlayerJoinedGameRoom(SocketIOEvent ev){
    if (onPlayerJoinedGameRoom != null) onPlayerJoinedGameRoom(ev);
  }

  public static void PlayerLeftGameRoom(SocketIOEvent ev){
    if (onPlayerLeftGameRoom != null) onPlayerLeftGameRoom(ev);
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

  protected SocketIOComponent socket;

  void Start(){
    socket = GetComponent<SocketIOComponent>();

    socket.On("create:gameroom:success", GameRoomCreated);
    socket.On("join:gameroom:success", GameRoomJoined);
    socket.On("left:gameroom", LeftGameRoom);
    socket.On("gamerooms:updated", GameRoomsUpdated);
    socket.On("player:left:gameroom", PlayerLeftGameRoom);
    socket.On("gamerooms:receive-update", ReceivedGameRoomsUpdate);
    socket.On("game:load", LoadGame);

    Application.LoadLevel("Lobby");
  }
}
