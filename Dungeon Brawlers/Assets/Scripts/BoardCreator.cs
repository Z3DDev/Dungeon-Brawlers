using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour {
    public class Count {
        public int minimum;
        public int maximum;

        public Count (int min, int max) {
            minimum = min;
            maximum = max;
        }
    }
    public enum TileType {
        Wall, Floor, 
    }

    public int columns;                                     //Number of Columns on the Board
    public int rows;                                        //Number of Rows on the Board
    public IntRange numRooms = new IntRange(10, 12);        //The Range of the Number of Rooms to be Generated on the Board
    public IntRange numCorridors = new IntRange(11, 14);    //The Range of the Number of Corridors to be Generated on the Board
    public IntRange roomWidth = new IntRange(5, 10);        //The Range of Widths Rooms can have on the Board
    public IntRange roomHeight = new IntRange(5, 10);       //The Range of Height Rooms can have on the Board
    public IntRange corridorLength = new IntRange(6, 15);   //The Range of Length Corridors between Rooms can have on the Board

    public Count obstacleCount = new Count(1, 5);
    public Count chestCount = new Count(1, 5);
    public Count grassCount = new Count(1, 5);
    public GameObject exit;
    public GameObject[] innerFloorTile;
    //Floor Tile GameObjects
    public GameObject[] floorTiles;
    public GameObject[] f_westT, f_eastT, f_northT, f_southT, f_northwestT, f_northeastT, f_southwestT, f_southeastT;
    public GameObject[] innerWallTiles;
    //Inner Wall Tile GameObjects
    public GameObject[] i_westWT, i_eastWT, i_northWT, i_southWT, i_northwestWT, i_northeastWT, i_southwestWT, i_southeastWT;
    //Outer Wall Tile GameObjects
    public GameObject[] outerWallTiles;
    
    public GameObject[] o_westWT, o_eastWT, o_northWT, o_southWT, o_northwestWT, o_northeastWT, o_southwestWT, o_southeastWT;
    public GameObject[] chestTiles;
    public GameObject[] obstacleTiles;
    public GameObject[] grassTiles;
    public GameObject[] enemyTiles;

    public TileType[] [] tiles;                            //A Jagged Array of Tile Types
    public Room[] rooms;                                   //All the Rooms that are created for the Board
    public Corridor[] corridors;                           //All the Corridors that are created for the Board
    private Transform boardHolder;                          //GameObject that acts as a container for all the generated objects on the Board

    void SetupTilesArray() {
        tiles = new TileType[columns][];

        for(int i = 0; i < tiles.Length; i++) {
            tiles[i] = new TileType[rows];
        }
    }

    void CreateRoomsAndCorridors() {
        rooms = new Room[numRooms.Random];                  //Create the Rooms Array with a Random Size
        corridors = new Corridor[numCorridors.Random];      //Create the Corridors Array with a Random Size

        //Create the First Room and Corridor
        rooms[0] = new Room();
        corridors[0] = new Corridor();

        //Setup the First Room (No Previous Corridor)
        rooms[0].SetupRoom(roomWidth, roomHeight, columns, rows);
        //Setup the First Corridor using the First Room
        corridors[0].SetupCorridor(rooms[0], corridorLength, roomWidth, roomHeight, columns, rows, true);

        for(int i = 1; i < rooms.Length; i++) {
            rooms[i] = new Room();                          //Create a Room
            rooms[i].SetupRoom(roomWidth, roomHeight, columns, rows, corridors[i - 1]); //Setup the Room (From Previous Corridor)

            if(i < corridors.Length) {
                corridors[i] = new Corridor();              //Create a Corridor
                corridors[i].SetupCorridor(rooms[i], corridorLength, roomWidth, roomHeight, columns, rows, false); //Setup the Corridor (From Previous Room)
            }
        }

        Debug.Log("Step 1");
    }

    void SetTilesValuesForRooms() {
        //Go through all the Rooms
        for(int i = 0; i < rooms.Length; i++) {
            Room currentRoom = rooms[i];

            for(int j = 0; j < currentRoom.roomWidth; j++) {        //Foreach Room go through it's Width
                int xCord = currentRoom.xPos + j;

                for(int k = 0; k < currentRoom.roomHeight; k++) {   //Foreach Horizontal Tile, go Vertically through the Rooms Height
                    int yCord = currentRoom.yPos + k;

                    tiles[xCord][yCord] = TileType.Floor;           //Coordinates in the Jagged Array are based on the Rooms position and it's Width/Height
                }
            }
        }

        Debug.Log("Step 2");
    }

    void SetTilesValuesForCorridors() {
        for(int i = 0; i < corridors.Length; i++) {                   //Go through all the Corridors
            Corridor currentCorridor = corridors[i];

            for(int j = 0; j < currentCorridor.corridorLength; j++) {   //And through it's Length
                //Start the coordinates at the start of the Corridor
                int xCord = currentCorridor.startXPos;
                int yCord = currentCorridor.startYPos;

                //Switch Statement for Direction of the Corridor
                //Add/Subtract from the appropriate coordinate based on the length of the loop
                switch(currentCorridor.direction) {
                    case Direction.North:
                        yCord += j;
                        break;
                    case Direction.East:
                        xCord += j;
                        break;
                    case Direction.South:
                        yCord -= j;
                        break;
                    case Direction.West:
                        yCord -= j;
                        break;
                }

                //Set the Tile at these coordinates to Floor
                tiles[xCord][yCord] = TileType.Floor;
            }
        }

        Debug.Log("Step 3");
    }

    void InstantiateTiles() {
        for(int i = 0; i < tiles.Length; i++) {
            for(int j = 0; j < tiles[i].Length; j++) {
                InstantiateFromArray(floorTiles, i, j);

                if(tiles[i][j] == TileType.Wall) {
                    InstantiateFromArray(innerWallTiles, i, j);
                }
            }
        }

        Debug.Log("Step 4");
    }

    void InstantiateInnerWalls() {

    }

    void InstantiateOuterWalls() {

    }

    void InstantiateVerticalWalls() {

    }

    void InstantiateHorizontalWalls() {

    }

    void InstantiateFromArray(GameObject[] prefabs, float xCord, float yCord) {
        int randomIndex = Random.Range(0, prefabs.Length);             //Create a Random Index for the Array
        Vector3 position = new Vector3(xCord, yCord, 0f);

        GameObject tileInstance = Instantiate(prefabs[randomIndex], position, Quaternion.identity) as GameObject;

        tileInstance.transform.parent = boardHolder.transform;
    Debug.Log("Step 5");
    }

    private void Start() {
        boardHolder = new GameObject("BoardHolder").transform;

        SetupTilesArray();

        CreateRoomsAndCorridors();

        SetTilesValuesForRooms();
        SetTilesValuesForCorridors();

        InstantiateTiles();
        InstantiateInnerWalls();
        InstantiateOuterWalls();
    }
}