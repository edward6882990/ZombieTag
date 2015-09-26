using UnityEngine;
using SocketIO;
using System.Collections;

namespace Lobby {
  public class LeaveGameButton : MonoBehaviour {
    protected SocketIOComponent socket;

    void Start (){
      socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
    }

    public void OnClick(){
      socket.Emit("leave:gameroom");
    }
  }
}