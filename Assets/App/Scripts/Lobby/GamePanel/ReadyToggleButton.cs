using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class ReadyToggleButton : MonoBehaviour {
    protected SocketIOComponent socket;

    void Start(){
      socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    }

    void SendReadySignal(){
      socket.Emit("ready");
    }
  }
}