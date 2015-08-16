using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  protected SocketIOComponent socket;

  void Start(){
    socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
  }

  public void CreateGameRoom(){
    Dictionary<string, string> data = new Dictionary<string, string>();
    data["type"] = "private";
    socket.Emit("create:gameroom", new JSONObject(data));
  }
}