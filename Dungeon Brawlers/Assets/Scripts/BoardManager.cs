using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
    [Serializable]
    public class Count {
        public int minimum;
        public int maximum;

        public Count (int min, int max) {
            minimum = min;
            maximum = max;
        }
    }

    public int columns;
    public int rows;
    public Count obstacleCount = new Count(1, 5);
    public Count chestCount = new Count(1, 5);
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
    public GameObject[] enemyTiles;

    private Transform boardHolder;
    private List <Vector3> gridPositions = new List <Vector3> ();
    
    void InitialiseList() {
        gridPositions.Clear();

        for(int x = 1; x < columns - 1; x++) {
            for(int y = 1; y < rows - 1; y++) {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup() {
        boardHolder = new GameObject("Board").transform;

        for(int x = -2; x < columns + 2; x++) {
            for(int y = -2; y < rows + 2; y++) {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                // Floor Tiles
                if(x == 0 || x == columns - 1 || y == 0 || y == rows - 1) {
                    if(x == 0) {
                        toInstantiate = f_westT[Random.Range(0, f_westT.Length)];
                    }
                    
                    else if(x == columns - 1) {
                        toInstantiate = f_eastT[Random.Range(0, f_eastT.Length)];
                    }

                    else if(y == 0) {
                        toInstantiate = f_southT[Random.Range(0, f_southT.Length)];
                    }

                    else if(y == rows - 1) {
                        toInstantiate = f_northT[Random.Range(0, f_northT.Length)];
                    }

                    else {
                        toInstantiate = innerFloorTile[Random.Range(0, innerFloorTile.Length)];
                    }
                }
                // Corner Floor Tiles
                if(x == 0 && y == rows - 1) {
                    toInstantiate = f_northwestT[Random.Range(0, f_northwestT.Length)];
                }   
                
                if(x == columns - 1 && y == rows - 1) {
                    toInstantiate = f_northeastT[Random.Range(0, f_northeastT.Length)];
                }   

                if(x == 0 && y == 0) {
                    toInstantiate = f_southwestT[Random.Range(0, f_southwestT.Length)];
                }   

                if(x == columns - 1 && y == 0) {
                    toInstantiate = f_southeastT[Random.Range(0, f_southeastT.Length)];
                }   
                // Inner Wall Tiles
                if(x == - 1 || x == columns || y == - 1 || y == rows) {
                    if(x == - 1) {
                        toInstantiate = i_westWT[Random.Range(0, i_westWT.Length)];
                    }
                    
                    else if(x == columns) {
                        toInstantiate = i_eastWT[Random.Range(0, i_eastWT.Length)];
                    }

                    else if(y == - 1) {
                        toInstantiate = i_southWT[Random.Range(0, i_southWT.Length)];
                    }

                    else if(y == rows) {
                        toInstantiate = i_northWT[Random.Range(0, i_northWT.Length)];
                    }

                    else if(x == - 1 && y == rows) {
                        toInstantiate = i_northwestWT[Random.Range(0, i_northwestWT.Length)];
                    }

                    else {
                        toInstantiate = innerWallTiles[Random.Range(0, innerWallTiles.Length)];
                    }                    
                }
                // Corner Inner Wall Tiles
                if(x == -1 && y == rows) {
                    toInstantiate = i_northwestWT[Random.Range(0, i_northwestWT.Length)];
                }   
                
                if(x == columns && y == rows) {
                    toInstantiate = i_northeastWT[Random.Range(0, i_northeastWT.Length)];
                }   

                if(x == -1 && y == -1) {
                    toInstantiate = i_southwestWT[Random.Range(0, i_southwestWT.Length)];
                }   

                if(x == columns && y == -1) {
                    toInstantiate = i_southeastWT[Random.Range(0, i_southeastWT.Length)];
                }   

                // Outer Wall Tiles
                if(x == - 2 || x == columns + 1 || y == - 2 || y == rows + 1) {
                    if(x == - 2) {
                        toInstantiate = o_westWT[Random.Range(0, o_westWT.Length)];
                    }
                    
                    else if(x == columns + 1) {
                        toInstantiate = o_eastWT[Random.Range(0, o_eastWT.Length)];
                    }

                    else if(y == - 2) {
                        toInstantiate = o_southWT[Random.Range(0, o_southWT.Length)];
                    }

                    else if(y == rows + 1) {
                        toInstantiate = o_northWT[Random.Range(0, o_northWT.Length)];
                    }

                    else {
                        toInstantiate = outerWallTiles[Random.Range(0, innerWallTiles.Length)];
                    }
                }
                // Corner Outer Wall Tiles
                if(x == -2 && y == rows + 1) {
                    toInstantiate = o_northwestWT[Random.Range(0, o_northwestWT.Length)];
                }   
                
                if(x == columns + 1 && y == rows + 1) {
                    toInstantiate = o_northeastWT[Random.Range(0, o_northeastWT.Length)];
                }   

                if(x == - 2 && y == - 2) {
                    toInstantiate = o_southwestWT[Random.Range(0, o_southwestWT.Length)];
                }   

                if(x == columns + 1 && y == - 2) {
                    toInstantiate = o_southeastWT[Random.Range(0, o_southeastWT.Length)];
                }   

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                
                instance.transform.SetParent(boardHolder);
            }
        }

        for(int x = 1; x < columns - 1; x++) {
            for(int y = 1; y < rows - 1; y++) {
                GameObject toInstantiate = innerFloorTile[Random.Range(0, innerFloorTile.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition() {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) {
        int objectCount = Random.Range(minimum, maximum + 1);
        for(int i = 0; i < objectCount; i++) {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level) {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(obstacleTiles, obstacleCount.minimum, obstacleCount.maximum);
        LayoutObjectAtRandom(chestTiles, chestCount.minimum, chestCount.maximum);

        /* int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount); */
        
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}
