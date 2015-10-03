using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
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
      string lobbyPlayerAssetPath = "Assets/App/Prefabs/Lobby/LobbyPlayer.prefab"; 

      float x = 0;
      float y = -(position * (LobbyPlayer.HEIGHT + LOBBY_PLAYER_VERTICAL_MARGIN));
      Vector2 positionVector = new Vector2(x, y);

      GameObject go_lobbyPlayer = 
        Instantiate(
          AssetDatabase.LoadAssetAtPath<GameObject>(lobbyPlayerAssetPath)
        ) as GameObject;

      go_lobbyPlayer.name = playerId;
      go_lobbyPlayer.transform.SetParent(transform);
      go_lobbyPlayer.transform.Find("Text").GetComponent<Text>().text = playerId;
      go_lobbyPlayer.GetComponent<RectTransform>().anchoredPosition = positionVector;

      if (isOwner){
        go_lobbyPlayer.GetComponent<Image>().color = new Color32(252, 254, 159, 255);
      }

      lobbyPlayers.Add(go_lobbyPlayer);
    }
  }
}