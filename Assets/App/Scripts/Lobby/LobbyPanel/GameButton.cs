using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class GameButton : MonoBehaviour {
    protected SocketIOComponent socket;
    protected string gameId;

    public const int WIDTH  = 320;
    public const int HEIGHT = 30;


    public void SetGameId(string id){
      gameId = id;
    }

    public void JoinGameRoom(){
      Dictionary<string, string> data = new Dictionary<string, string>();

      data["gameId"] = gameId;

      socket.Emit("join:gameroom", new JSONObject(data));
    }

    void Start(){
      socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    }

  }
}