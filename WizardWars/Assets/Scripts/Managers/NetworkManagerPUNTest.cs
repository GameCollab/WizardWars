using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerPUNTest : Photon.MonoBehaviour {

    public GameObject[] SpawnPoint; //where to spawn

    public int state = 0;

    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update ()
    {
        
    }

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("v1.0");    //version that people will play, 1.0 with 1.0
    }

    //overload
    void OnJoinedLobby()
    {
        state = 1;
    }
    //overload
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null); //will create a room
    }
    //overload
    void OnJoinedRoom()
    {
        state = 2;
    }

    void OnGUI() {
        switch (state)
        {
            case 0:
                if(GUI.Button(new Rect(10,10,100,30),"Connect"))
                {
                    Connect();
                }
                break;
            case 1:
                //if connect to the server success,
                GUI.Label(new Rect(10, 10, 100, 30), "Connected");
                if(GUI.Button(new Rect(10,40,150,30), "Searching Server..."))
                {
                    //PhotonNetwork.JoinRoom("myRoomName");
                    PhotonNetwork.JoinRandomRoom();
                }
                break;
            case 2:
                //Waiting till the room full
                GUI.Label(new Rect(10, 10,400,30), "Waiting for player, currenlty in room: "+ PhotonNetwork.playerList.Length);
                if (PhotonNetwork.playerList.Length == 2 & PhotonNetwork.isMasterClient == true)
                {
                    this.GetComponent<PhotonView>().RPC("StartGame", PhotonTargets.All);
                }
                break;
            case 3:
                //Select Character
                GUI.Label(new Rect(10, 10, 100, 30), "Select Character");
                if (GUI.Button(new Rect(10, 40, 100, 30), "Wizzard 101"))
                {
                    Spawn(0, "TestPlayer");
                }
                break;
            case 4:
                //go to ingame
                break;
        }
    }

    /*
     * team = player's team 
     * CharacterName must be a name in Resources Folder!
     */
    void Spawn(int team, string characterName)
    {
        state = 4;
        Debug.Log("Spawning... " + characterName);

        //if(team different) do different spawn point

        GameObject spawnPos = SpawnPoint[Random.Range(0, SpawnPoint.Length)];
        GameObject testPlayer = PhotonNetwork.Instantiate(characterName, spawnPos.transform.position, spawnPos.transform.rotation, 0);

        //enable anything that the player can control here: player script etc
        testPlayer.GetComponent<CharacterController>().enabled = true; //only us(who join the lobby) can control the character, not other player in the network
        //testPlayer.GetComponent<CharacterController>().enabled = true;

        Debug.Log(characterName + " has been spawned!");
    }

    [PunRPC]
    public void StartGame()
    {
        state = 3;
    }
}
