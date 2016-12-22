using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerPUNTest : Photon.MonoBehaviour {

    public bool _EnabledStats = false;
    public string _gameVersion = "V1.0";  //version that people will play (our arbitary game version), 1.0 with 1.0

    public string _defRegion = "usw";
    /*  Region	    Hosted in	Token
        Asia	    Singapore	asia
        Australia	Melbourne	au
        Canada,East	Montreal	cae
        Europe	    Amsterdam	eu
        India	    Chennai     in
        Japan	    Tokyo	    jp
        SAmerica	Sao Paulo	sa
        SKorea	    Seoul	    kr
        USA, East	Washington	us
        USA, West	San José	usw
        */

    [HideInInspector]
    bool _isPlayer = true;
    [HideInInspector]
    bool _isSpectator = false;
    [HideInInspector]
    int _playerCount = 0;           //Actual Player that will play
    public int _playerLimit = 1;    //player capacity before the game can start
    public int _roomLimit = 10;     //room capacity, to support spectator
    [HideInInspector]
    int _readyState = 0;    //if player in the room = readyState, start the game (temporary)
    [HideInInspector]
    string myRoomName;

    public GameObject[] SpawnPoint; //Spawn Position

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Below Variables for testing purposes:
    public bool _TestingMode = true;

    /// <summary>
    /// _myState: (arbitary)
    /// 0 = offline, not connected to the server
    /// 1 = connected to the server, already in lobby
    /// 2 = connected to a room, wait condition to start the game
    /// 3 = Game is Starting, state when every client loading resources
    /// 4 = Select Character, Ready State
    /// 5 = game ON, hide all the UI
    /// 9 = on trying to connect to the server
    /// 10 = not able to connect to server
    /// 11 = DC after connected to server
    /// 100 = spectator mode
    /// </summary>
    [HideInInspector]
    int _myState = 0;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // MonoBehaviour
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.playerName = "greatWizard";
        myRoomName = "";
        PhotonNetwork.NetworkStatisticsEnabled = _EnabledStats;
    }
	// Update is called once per frame
	void Update ()
    {
      
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC & PRIVATE FUNCTIONS
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Functions to auto connect to Photon server as configured in the editor (saved in PhotonServerSettings file). 
    /// </summary>
    /// <param name="gameVersion">version that people will play (our arbitary game version), 1.0 with 1.0</param>
    public void Connect(string gameVersion = "V1.0")
    {
        _myState = 9;
        if (gameVersion != "") _gameVersion = gameVersion; 
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
    }

    /// <summary>
    /// Functions to Connect to a specific region
    /// </summary>
    /// <param name="region">region token</param>
    public void ConnectTo(string region = "usw", string gameVersion = "V1.0")
    {
        _myState = 9;
        if (gameVersion != "") _gameVersion = gameVersion;
        switch(region)
        {
            case "eu": PhotonNetwork.ConnectToRegion(0, gameVersion); break;
            case "us": PhotonNetwork.ConnectToRegion(CloudRegionCode.us, gameVersion); break;
            case "asia": PhotonNetwork.ConnectToRegion(CloudRegionCode.asia, gameVersion); break;
            case "jp": PhotonNetwork.ConnectToRegion(CloudRegionCode.jp, gameVersion); break;
            case "au": PhotonNetwork.ConnectToRegion(CloudRegionCode.au, gameVersion); break;
            case "usw": PhotonNetwork.ConnectToRegion(CloudRegionCode.usw, gameVersion); break;
            case "sa": PhotonNetwork.ConnectToRegion(CloudRegionCode.sa, gameVersion); break;
            case "cae": PhotonNetwork.ConnectToRegion(CloudRegionCode.cae, gameVersion); break;
            default: PhotonNetwork.ConnectToBestCloudServer(gameVersion); break;
        }
    }
    /// <summary>
    /// Functions to reconnect after DC
    /// </summary>
    public void reConnect()
    {
        _myState = 9;
         PhotonNetwork.Reconnect();
        //todo: work with webserver, need to save roomname atleast, so if player dc from a room, it can rejoin and continue ReJoinRoom or ReconnectAndRejoin
    }

    /// <summary>
    /// function to create a ROOM after already join a lobby
    /// </summary>
    public void createmyRoom(string roomName = "")
    {
        if (PhotonNetwork.CreateRoom(roomName))
        {
            PhotonNetwork.automaticallySyncScene = true;
            Debug.Log("Success!");
            return;
        }
        else
        {
            for (int i = 0; i < 10; i++)
                if (PhotonNetwork.CreateRoom(roomName + "(" + i + ")"))
                {
                    PhotonNetwork.automaticallySyncScene = true;
                    break;
                }
        }
        Debug.Log("Creating a room fail!");
    }

    public string getRoomName()
    {
        string tempName = "";
        if (PhotonNetwork.isNonMasterClientInRoom || PhotonNetwork.isMasterClient)
            tempName = PhotonNetwork.room.Name;
        if (tempName.Length > 20)
            tempName = tempName.Substring(0, 20) + "...";
        return tempName;
    }

    public int getPlayerCountInRoom()
    {
        return _playerCount;
    }

    void setPlayerLimit(int number)
    {
        _playerLimit = number;
    }

    public int getPlayerLimit()
    {
        return _playerLimit;
    }

    public int getSpectatorCountInRoom()
    {
        return PhotonNetwork.playerList.Length - _playerCount;
    }

    public void leavethisRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    /// <summary>
    /// fast function to send info to all Connected without parameters
    /// </summary>
    public void sendToAll(NetworkManagerPUNTest from, string method)
    {
        from.GetComponent<PhotonView>().RPC(method, 0); //0 = PhotonTargets.All
    }
    /// <summary>
    /// fast function to send info to all Connected with parameters
    /// </summary>
    public void sendToAll(NetworkManagerPUNTest from, string method, params object[] parameters)
    {
        from.GetComponent<PhotonView>().RPC(method, 0, parameters); //0 = PhotonTargets.All
    }

    /// <summary>
    /// fast function to send info to Master without parameters
    /// </summary>
    public void sendToMaster(NetworkManagerPUNTest from, string method)
    {
        from.GetComponent<PhotonView>().RPC(method, PhotonTargets.MasterClient);
    }
    /// <summary>
    /// fast function to send info to Master with parameters
    /// </summary>
    public void sendToMaster(NetworkManagerPUNTest from, string method, params object[] parameters)
    {
        from.GetComponent<PhotonView>().RPC(method, PhotonTargets.MasterClient, parameters);
    }

    /// <summary>
    ///  for Testing Purpose only, GameManager should handle this!
    /// </summary>
    /// <param name="team"> player's team </param>
    /// <param name="characterName">CharacterName must be a name in Resources Folder!</param>
    public void Spawn(int team, string characterName)
    {
        Debug.Log("Spawning... " + characterName);

        //if(team different) do different spawn point

        GameObject spawnPos = SpawnPoint[Random.Range(0, SpawnPoint.Length)];
        GameObject testPlayer = PhotonNetwork.Instantiate(characterName, spawnPos.transform.position, spawnPos.transform.rotation, 0);

        //enable anything that the player can control here: player script etc
        testPlayer.GetComponent<CharacterController>().enabled = true; //only us(who join the lobby) can control the character, not other player in the network
        //testPlayer.GetComponent<CharacterController>().enabled = true;

        Debug.Log(characterName + " has been spawned!");
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Overloading Functions
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary> overload - connected to the server, ready to create a room, when the client already in a lobby </summary>
    void OnJoinedLobby()
    {
        _myState = 1;
    }
    /// <summary> overload - when the client try to join a room, but failed due to usually NO ROOM </summary>
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null); //will create a room with generated roomname(null) from server
    }
    /// <summary> overload - when the client already in a room </summary>
    void OnJoinedRoom()
    {
        if (_isSpectator)
        {
            _myState = 100;
            sendToMaster(this, "notifyHostPlayer", 2);
            return;
        }

        if (PhotonNetwork.isMasterClient == true)
        {
            _isPlayer = true;
            _isSpectator = false;
            _playerCount = 1;
        }
        else
        {
            sendToMaster(this, "notifyHostPlayer",0);
        }

        _myState = 2;
    }

    /// <summary> overload - when the client cannot connect to Photon server  </summary>
    void OnFailedToConnectToPhoton()
    {
        _myState = 10;
    }
    /// <summary> overload - called when Disconnected from Photon server  </summary>
    void OnDisconnectedFromPhoton()
    {
        _myState = 11;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Testing Functions
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void OnGUI()
    {
        string tempName;

        if (_TestingMode)   // CHECK THIS VALUE!
        { 
            if (_myState > 0 )
            {
                //network Statistic:
                if (_EnabledStats) GUI.Label(new Rect(10, 400, 500, 1200), PhotonNetwork.NetworkStatisticsToString());

                //ping to the connected server:
                GUI.Label(new Rect(500, 10, 100, 25), "Ping: " + PhotonNetwork.GetPing());

                //show each player connected nickname:
                if (_myState < 5)
                {
                    for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
                        GUI.Label(new Rect(500, ((i + 1) * 25) + 10, 200, 25), "Player " + i + " : " + PhotonNetwork.playerList[i].NickName);
                }
            }

            switch(_myState)
            {
                case 0:
                    PhotonNetwork.playerName = GUI.TextField(new Rect(10, 40, 150, 25), PhotonNetwork.playerName, 32);
                    if (GUI.Button(new Rect(10, 10, 100, 25), "Connect"))
                    {
                        Connect();
                    }
                    break;
                case 9:
                    GUI.Label(new Rect(10, 10, 100, 30), "Connecting....");
                    break;
                case 10:
                    PhotonNetwork.playerName = GUI.TextField(new Rect(10, 40, 150, 25), PhotonNetwork.playerName, 32);
                    GUI.Label(new Rect(500, 10, 400, 30), "FAIL to Connect to the server!");
                    if (GUI.Button(new Rect(10, 10, 100, 25), "Connect"))
                    {
                        Connect();
                    }
                    break;
                case 11:
                    GUI.Label(new Rect(500, 10, 100, 30), "Disconnected!!");
                    if (GUI.Button(new Rect(10, 10, 100, 25), "Reconnect"))
                    {
                        reConnect();
                    }
                    break;

                //100 - Spectator Mode:
                case 100:
                    if(GUI.Button(new Rect(10, 10, 100, 30), "Leave Room"))
                    {
                        leavethisRoom();
                    }
                    //this ROOM INFO:
                    GUI.Label(new Rect(10, 40, 400, 25), "ROOM NAME            : " + getRoomName());
                    GUI.Label(new Rect(10, 65, 400, 25), "Player in the Room   : " + getPlayerCountInRoom());
                    GUI.Label(new Rect(10, 90, 400, 25), "Spectator in the Room: " + getSpectatorCountInRoom());
                    break;

                case 1:
                    //if connect to the server success,
                    GUI.Label(new Rect(10, 10, 100, 30), "Connected!!");
                    myRoomName = GUI.TextField(new Rect(110, 10, 80, 25), myRoomName, 32);
                    if (GUI.Button(new Rect(190, 10, 100, 25), "Create Room!"))
                    {
                        createmyRoom(myRoomName);
                    }

                    //show open room list in lobby, so players can pick and join
                    RoomInfo[] listofCurrentRoom = PhotonNetwork.GetRoomList();
                    GUI.Label(new Rect(10, 40, 50, 25), " ROOM ");
                    GUI.Label(new Rect(60, 40, 120, 25), "|  NAME ");
                    GUI.Label(new Rect(180, 40, 200, 25), "| PlayerCount ");
                    for (int i = 0; i < listofCurrentRoom.Length; i++)
                    {
                        GUI.Label(new Rect(10, ((i + 2) * 25) + 15, 50, 25), "  "+i);
                        if (listofCurrentRoom[i].Name.Length > 15) tempName = listofCurrentRoom[i].Name.Substring(0, 15) + "...";
                        else tempName = listofCurrentRoom[i].Name;
                        GUI.Label(new Rect(60, ((i + 2) * 25) + 15, 120, 25),"| "+tempName);
                        GUI.Label(new Rect(180, ((i + 2) * 25) + 15, 50, 25),"| "+listofCurrentRoom[i].PlayerCount);
                        if(GUI.Button(new Rect(250, ((i + 2) * 25) + 15, 50, 25), "Join"))
                        {
                            _isPlayer = true;
                            _isSpectator = false;
                            PhotonNetwork.JoinRoom(listofCurrentRoom[i].Name);
                            GUI.Label(new Rect(400, ((i + 2) * 25) + 15, 100, 25), "Loading...");
                        }
                        if (GUI.Button(new Rect(300, ((i + 2) * 25) + 15, 100, 25), "Spectate"))
                        {
                            _isPlayer = false;
                            _isSpectator = true;
                            PhotonNetwork.JoinRoom(listofCurrentRoom[i].Name);
                            GUI.Label(new Rect(400, ((i + 2) * 25) + 15, 100, 25), "Loading...");
                        }
                    }

                    //join a random room:
                    if (GUI.Button(new Rect(300, 10, 160, 25), "join a random Room"))
                    {
                        PhotonNetwork.JoinRandomRoom();
                    }
                    break;
                case 2:
                    //Waiting till the room full
                    GUI.Label(new Rect(10, 10, 400, 30), "Player In this Room: " + _playerCount +" / "+ _playerLimit);
                    if (_playerCount <= _playerLimit & PhotonNetwork.isMasterClient == true)
                    {
                        //ready to start the game!
                        if(GUI.Button(new Rect(10, 40, 100, 25), "Start Game"))
                        {
                            PhotonNetwork.room.IsVisible = false;
                            sendToAll(this, "LoadResources");
                        }
                    }
                    //this ROOM INFO:
                    GUI.Label(new Rect(10, 70, 400, 25), "ROOM NAME:" + getRoomName());

                    if (_playerCount > _playerLimit)
                    {
                        GUI.Label(new Rect(10, 40, 400, 25), "Cannot Start the Game, OverWeight!");
                    }
                    
                    if(_isSpectator)
                    {
                        GUI.Label(new Rect(10, 95, 150, 25), "Status : Spectator");
                        if (GUI.Button(new Rect(160, 95, 100, 25), "Play?"))
                        {
                            _isPlayer = true;
                            _isSpectator = false;
                            sendToMaster(this, "notifyHostPlayer",0);
                        }
                    }

                    if(_isPlayer)
                    {
                        GUI.Label(new Rect(10, 95, 150, 25), "Status : Player");
                        if (GUI.Button(new Rect(160, 95, 100, 25), "Spectate?"))
                        {
                            _isPlayer = false;
                            _isSpectator = true;
                            sendToMaster(this, "notifyHostPlayer",1);
                        }
                    }
                   
                    GUI.Label(new Rect(10, 120, 400, 25), "Spectator in the Room: " + getSpectatorCountInRoom());

                    break;
                case 3:
                    //Select Character
                    //on actual game, this need to be done by GameManager, when the game is started
                    GUI.Label(new Rect(10, 10, 150, 30), "Select Character:");
                    if (GUI.Button(new Rect(10, 40, 100, 25), "Wizzard 101"))
                    {
                        sendToAll(this, "IncrementReady");
                        _myState = 4;
                    }

                    //this ROOM INFO:
                    GUI.Label(new Rect(10, 70, 400, 25), "ROOM NAME             : " + getRoomName());
                    GUI.Label(new Rect(10, 95, 400, 25), "Player in the Room    : " + getPlayerCountInRoom());
                    GUI.Label(new Rect(10, 120, 400, 25), "Spectator in the Room: " + getSpectatorCountInRoom());
                    break;
                case 4:
                    GUI.Label(new Rect(10, 10, 150, 30), "Ready : "+_readyState+"/"+ _playerLimit);
                    if (_readyState == _playerLimit & PhotonNetwork.isMasterClient == true)
                    {
                        //ready to start the game!
                        if (GUI.Button(new Rect(10, 40, 100, 25), "Start!"))
                        {
                            sendToAll(this, "StartGame");
                        }
                    }
                    break;
                case 5:
                    //go to ingame
                    break;
            }
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //[PunRPC] = Follower functions, triggered by clients
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// this function will notify host about a client status
    /// </summary>
    [PunRPC]
    void notifyHostPlayer(int op = 0)
    {
        if(PhotonNetwork.isMasterClient == true)
        {
            if(op == 0) //inc _playerCount
            {
                this.GetComponent<PhotonView>().RPC("changePlayerLimit", 0, _playerLimit);  //also synch _playerLimit for the first time join the room
                this.GetComponent<PhotonView>().RPC("changePlayerCount", 0, (_playerCount+1));
            }
            if(op == 1) //dec _playerCount
            {
                this.GetComponent<PhotonView>().RPC("changePlayerCount", 0, (_playerCount - 1));
            }
            if(op == 2) //get _playerLimit
            {
                this.GetComponent<PhotonView>().RPC("changePlayerCount", 0, _playerCount);
            }
        }
    }

    /// <summary>
    /// this function will notify Clients
    /// </summary>
    [PunRPC]
    void notifyOthers(int op = 0)
    {
        if (PhotonNetwork.isMasterClient == true)
        {
            if (op == 0)    //change _playerLimit
            {
                this.GetComponent<PhotonView>().RPC("changePlayerLimit", 0, _playerLimit);
            }
            if (op == 1)
            {
          
            }
        }
    }

    /// <summary>
    /// synchronize _playerCount with the master Client
    /// </summary>
    /// <param name="number">_playerCount from master Client</param>
    [PunRPC]
    void changePlayerCount(int number) 
    {
        _playerCount = number;
    }

    /// <summary>
    /// synchronize _playerLimit with the master Client
    /// </summary>
    /// <param name="number">_playerLimit from master Client</param>
    [PunRPC]
    void changePlayerLimit(int number)
    {
        _playerLimit = number;
    }

    /// <summary>
    /// Load Resources State
    /// </summary>
    [PunRPC]
    void LoadResources()
    {
        //PhotonNetwork.LoadLevel("gamelevel");
        if(_isPlayer) _myState = 3;   //loading resources, change level
        if(_isSpectator) _myState = 100;
    }

    /// <summary>
    /// function to increment _readyState
    /// </summary>
    [PunRPC]
    void IncrementReady()
    {
        _readyState++;
    }

    /// <summary>
    /// Function to Start The game after loading resources
    /// </summary>
    [PunRPC]
    void StartGame()
    {
        if (_isPlayer)
        {
            _myState = 5;
            Spawn(0, "TestPlayer");
        }
        if(_isSpectator)
        {
            //start the timer maybe
        }
    }
}
