using UnityEngine;
using SocketIO;
using System.Collections;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviour {
  protected SocketIOComponent socket;
  protected bool sentMessage = false;
  void Start(){
    socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    socket.On("echo", OnEcho);
    socket.Connect();

    sentMessage = false;
  } 

  public void OnEcho(SocketIOEvent e){
    Debug.Log("echo");
  }
}