using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
  private void Start()
  {
    PhotonNetwork.NickName = "Player " + Random.Range(0, 999);

    PhotonNetwork.AutomaticallySyncScene = true;
    PhotonNetwork.GameVersion = "1";
    PhotonNetwork.ConnectUsingSettings();
  }

  public override void OnConnectedToMaster() => base.OnConnectedToMaster();

  public override void OnConnected() => base.OnConnected();

  public override void OnCreatedRoom() => base.OnCreatedRoom();

  public override void OnCreateRoomFailed(short returnCode, string message) => base.OnCreateRoomFailed(returnCode, message);

  public override void OnDisconnected(DisconnectCause cause) => base.OnDisconnected(cause);

  public override void OnJoinedLobby() => base.OnJoinedLobby();

  public override void OnJoinedRoom() => base.OnJoinedRoom();

  public void CreateRoom()
  {
    PhotonNetwork.CreateRoom("Jopa Room", new RoomOptions() { MaxPlayers = 4 });
  }

  public void JoinRandomRoom()
  {
    PhotonNetwork.JoinRandomRoom(); // TODO 
  }
}
