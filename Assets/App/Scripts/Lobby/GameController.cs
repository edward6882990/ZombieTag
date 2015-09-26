using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;
using Lobby;

namespace Lobby {
  public class GameController : MonoBehaviour {
    void Start(){
      SocketIOComponent socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();

      socket.Connect();
    }
  }
}

