using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class PlayersDisplay : MonoBehaviour {
    protected int LOBBY_PLAYER_VERTICAL_MARGIN = 20;

    protected List<GameObject> lobbyPlayers = new List<GameObject>();


    public void UpdatePlayersView(JSONObject players){
      DestroyAllPlayers();
      
      for(int i = 0; i < players.list.Count; i++) {
        CreateLobbyPlayerObject(players[i], i);
      }
    }

    void OnEnable(){
      Events.onGameRoomUpdated += GameRoomUpdated;
    }

    void OnDisable(){
      Events.onGameRoomUpdated -= GameRoomUpdated;
    }

    void GameRoomUpdated(SocketIOEvent ev){
      UpdatePlayersView(ev.data["players"]);
    }

    void DestroyAllPlayers(){
      for(int i = 0; i < lobbyPlayers.Count; i++) {
        Destroy(lobbyPlayers[i]);
      }
    }

    void CreateLobbyPlayerObject(JSONObject playerInfo, int position){
      string playerId = playerInfo["id"].str;
      bool   isOwner  = playerInfo["owner"].b;
      bool   isReady  = playerInfo["ready"].b;

      float x = 0;
      float y = -(position * (LobbyPlayer.HEIGHT + LOBBY_PLAYER_VERTICAL_MARGIN));
      Vector2 positionVector = new Vector2(x, y);

      GameObject go_lobbyPlayer = 
        Instantiate(
          Resources.Load("Prefabs/Lobby/LobbyPlayer")
        ) as GameObject;

      go_lobbyPlayer.name = playerId;
      go_lobbyPlayer.transform.SetParent(transform);
      go_lobbyPlayer.transform.Find("PlayerName").GetComponent<Text>().text = playerId;
      go_lobbyPlayer.GetComponent<RectTransform>().anchoredPosition = positionVector;
      go_lobbyPlayer.transform.Find("Ready").gameObject.active = isReady;

      if (isOwner){
        go_lobbyPlayer.GetComponent<Image>().color = new Color32(252, 254, 159, 255);
      }

      lobbyPlayers.Add(go_lobbyPlayer);
    }
  }
}