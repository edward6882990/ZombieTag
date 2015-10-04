using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lobby {
  public class ReadyToggleButton : MonoBehaviour {
    protected SocketIOComponent socket;
    protected string state = "Ready";

    public void SendSignal(){
      if (state == "Ready") {
        SendReadySignal();
      } else {
        SendCancelReadySignal();
      }
    }

    void Start(){
      socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    }

    void OnEnable(){
      Events.onReadySuccess += Ready;
      Events.onCancelReadySuccess += CancelledReady;
    }

    void OnDisable(){
      Events.onReadySuccess -= Ready;  
      Events.onCancelReadySuccess -= CancelledReady;
    }

    void Ready(SocketIOEvent ev){
      state = "Cancel";
      UpdateButtonText();
    }

    void CancelledReady(SocketIOEvent ev){
      state = "Ready";
      UpdateButtonText();
    }

    void UpdateButtonText(){
      transform.Find("Text").GetComponent<Text>().text = state;
    }

    void SendReadySignal(){
      Events.SendReadySignal(socket);
    } 

    void SendCancelReadySignal(){
      Events.SendCancelReadySignal(socket);
    }


  }
}