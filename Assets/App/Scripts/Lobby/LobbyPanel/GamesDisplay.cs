using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class GamesDisplay : MonoBehaviour {
    protected List<GameObject> buttonGameObjects = new List<GameObject>();
    protected SocketIOComponent socket;

    protected int waitInterval = 1000;

    protected int currentPage = 1;
    protected int totalPages = 1;

    public const int GAME_BUTTON_VERTICAL_MARGIN = 10;

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

      WaitUnitConnected();

      PullGameRoomsInfo();
    }

    void WaitUnitConnected(){
      while(!socket.IsConnected){ 
        Debug.Log("Not Connected: Wait for a bit ...");

        System.Threading.Thread.Sleep(waitInterval);
      }
    }

    void OnEnable(){
      Events.onLobbyUpdated += LobbyUpdated;
      Events.onReceivedLobbyUpdate += ReceivedLobbyUpdate;
    }

    void OnDisable(){
      Events.onLobbyUpdated -= LobbyUpdated;  
      Events.onReceivedLobbyUpdate -= ReceivedLobbyUpdate;
    }

    void LobbyUpdated(SocketIOEvent ev){
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
      Events.GetLobbyUpdate(socket, currentPage);
    }

    void ReceivedLobbyUpdate(SocketIOEvent ev){
      DestroyAllButtons();
      UpdateButtonsView(ev);
    }

    void DestroyAllButtons(){
      for(int i = 0; i < buttonGameObjects.Count; i++){
        Destroy(buttonGameObjects[i]);
      }
    }

    void UpdateButtonsView(SocketIOEvent ev){
      JSONObject games = ev.data["games"];

      for(int i = 0; i < games.list.Count; i++){
        CreateGameButton(games[i].str, i);
      }
    }

    void CreateGameButton(string gameId, int position){

      float x = position % 2 * GameButton.WIDTH;
      float y = -(position / 2 * (GameButton.HEIGHT + GAME_BUTTON_VERTICAL_MARGIN));
      Vector2 positionVector = new Vector2(x, y);

      GameObject go_button =
        Instantiate(
          Resources.Load("Prefabs/Lobby/GameButton")
        ) as GameObject;

      go_button.name = gameId;
      go_button.transform.SetParent(transform);
      go_button.GetComponent<GameButton>().SetGameId(gameId);
      go_button.transform.Find("Text").GetComponent<Text>().text = gameId;
      go_button.GetComponent<RectTransform>().anchoredPosition = positionVector;

      buttonGameObjects.Add(go_button);
    }
  } 
}