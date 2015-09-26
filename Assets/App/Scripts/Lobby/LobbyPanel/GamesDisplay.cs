using UnityEngine;
using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class GamesDisplay : MonoBehaviour {
    protected List<GameObject> gameButtons;
    protected SocketIOComponent socket;

    protected int currentPage = 1;
    protected int totalPages = 1;


    public void NextPage(){
      if (currentPage < totalPages) {
        currentPage ++;
        PullGameRoomsInfo();
      }
    }

    public void PrevPage(){
      if (currentPage > 1) {
        currentPage --;

        PullGameRoomsInfo();
      }
    }

    void Start(){
      socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
      PullGameRoomsInfo();
    }

    void OnEnable(){
      Events.onGameRoomsUpdated += GameRoomsUpdated;
      Events.onGameRoomReceiveUpdates += ReceivedGameRoomsUpdate;
    }

    void OnDisable(){
      Events.onGameRoomsUpdated -= GameRoomsUpdated;  
      Events.onGameRoomReceiveUpdates -= ReceivedGameRoomsUpdate;
    }

    void GameRoomsUpdated(SocketIOEvent ev){
      UpdatePageInfo(ev);
      PullGameRoomsInfo();
    }

    int GetTotalPagesFromJSON(SocketIOEvent ev){
      return Convert.ToInt32(ev.data["totalPages"].ToString());
    }

    void UpdatePageInfo(SocketIOEvent ev){
      totalPages = GetTotalPagesFromJSON(ev);
      if (currentPage > totalPages) currentPage = totalPages;
    }

    void PullGameRoomsInfo(){
      Dictionary<string, string> data = new Dictionary<string, string>();
      data["page"] = currentPage.ToString();
      socket.Emit("gamerooms:get-update", new JSONObject(data)); 
    }

    void ReceivedGameRoomsUpdate(SocketIOEvent ev){
      Debug.Log("received updated gamerooms");
    }

  } 
}