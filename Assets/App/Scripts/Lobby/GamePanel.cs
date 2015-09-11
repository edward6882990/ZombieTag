using UnityEngine;
using SocketIO;
using System.Collections;
using Lobby;

namespace Lobby {
  public class GamePanel : MonoBehaviour {
    protected List<Player> players;

    public void UpdatePlayers(List<Players> playersToUpdate){
      players = playersToUpdate;
    }
  }
}
