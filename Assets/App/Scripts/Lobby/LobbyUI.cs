// using UnityEngine;
// using System.Collections;

// [RequireComponent(typeof(LobbyPlayer))]
// class LobbyUI : MonoBehaviour {
//   protected LobbyPlayers[] playerPool;

//   const integer PLAYER_POOL_SIZE = 4;

//   void Start(){
//     playerPool = new LobbySlot[PLAYER_POOL_SIZE];
//   }

//   public void PlacePlayerIntoEmptySlot(LobbyPlayer player){
//     if(IsFull()) throw new Exception(@"Lobby is Full.");

//     for(int i = 0; i < PLAYER_POOL_SIZE; i++) {
//       if(playerPool[i] != null) playerPool[i] = 
//     }
//   }

//   public bool IsFull(){
//     for(int i = 0; i < PLAYER_POOL_SIZE; i++){
//       if (playerPool[i] != null) return false;
//     }

//     return true;
//   }

//   void Update(){
//     DisplayAllLobbyPlayers();
//   }

//   void DisplayLobbyPlaers(){
    
//   }
// }
