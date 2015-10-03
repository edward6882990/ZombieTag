using UnityEngine;
using SocketIO;
using System.Collections;

public class Boot : MonoBehaviour {
  void Update(){
    SocketIOComponent socket = transform.gameObject.GetComponent<SocketIOComponent>();
    if(socket != null && socket.IsConnected) Application.LoadLevel("Lobby");
  }
}