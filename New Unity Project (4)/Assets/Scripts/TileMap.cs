using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class TileMap : MonoBehaviour {
    

    [System.Serializable]

    public class Count
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    
    private List<Vector3> gridPositions = new List<Vector3>();


    
    public int EnemyCount;
    public GameObject[] enemyTiles;

    public GameObject ShopKeeper;

    public GameObject BlackShrine;
    public GameObject WhiteShrine;
    public GameObject GreenShrine;
    public GameObject BlueShrine;
    public GameObject RedShrine;
    public static int Black;
    public static int White;
    public static int Green;
    public static int Blue;
    public static int Red;

    public GameObject BlackSpace;
    public int WallCount;
    public GameObject selectedUnit;
   
    public TileType[] tileTypes;
    int index;
    public static int[,] tiles;
    Node[,] graph;



    int mapSizeX = 24;
    int mapSizeY = 18;

    void Start() {
        // Setup the selectedUnit's variable
        selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
        selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.y;
        selectedUnit.GetComponent<Unit>().map = this;
        GenerateDarkTiles();
        GenerateMapData();
        GeneratePathfindingGraph();
        //GenerateDarkTiles();
        GenerateMapVisual();
        //LayoutObjectAtRandom(enemyTiles, EnemyCount, EnemyCount);
        //GenerateEnemies();
        GenerateShopKeeper();
        GenerateBlackShrine();
        GenerateBlueShrine();
        GenerateGreenShrine();
        GenerateRedShrine();
        GenerateWhiteShrine();
    }


    //Make Dark Tiles
    void GenerateDarkTiles()
    {
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                Instantiate(BlackSpace, new Vector3(x, y, 0), Quaternion.identity);
            }
           
        }
    }
    
    void GenerateShopKeeper()
    {
        int RandomX = Random.Range(2, 11);
        int RandomY = Random.Range(2, 11);
        Instantiate(ShopKeeper, new Vector3(RandomX, RandomY + 0.6f, 0), Quaternion.identity);
    }

  public void GenerateBlackShrine()
    {
        if (Black > 1)
        {
            return;
        }
        if (TileMap.tiles[x, y] == 1 && Black <1)
        {
            int RandomX = Random.Range(2, 16);
            int RandomY = Random.Range(2, 16);
            Instantiate(BlackShrine, new Vector3(RandomX, RandomY, -1), Quaternion.identity);
            Black += 1;
        }
       
    }

    public void GenerateGreenShrine()
    {
        if (Green > 1)
        {
            return; 
        }
        if (TileMap.tiles[x, y] == 1 && Green <1)
        {
            int RandomX = Random.Range(2, 16);
            int RandomY = Random.Range(2, 16);
            Instantiate(GreenShrine, new Vector3(RandomX, RandomY, -1), Quaternion.identity);
            Green += 1;
        }
    }

    public void GenerateBlueShrine()
    {
      if (Blue >1)
        {
            return;
        }
        if (TileMap.tiles[x, y] == 1 && Blue <1)
        {
            int RandomX = Random.Range(2, 16);
            int RandomY = Random.Range(2, 16);
            Instantiate(BlueShrine, new Vector3(RandomX, RandomY +0.2f, -1), Quaternion.identity);
            Blue += 1;
        }
    }

  public void GenerateRedShrine()
    {
        if (Red > 1)
        {
            return;
        }
        if (TileMap.tiles[x, y] == 1 && Red < 1)
        {
            int RandomX = Random.Range(2, 16);
            int RandomY = Random.Range(2, 16);
            Instantiate(RedShrine, new Vector3(RandomX, RandomY +.02f, -1), Quaternion.identity);
            Red += 1;
        }
    }

    public void GenerateWhiteShrine()
    {
      if ( White > 1)
        {
            return;
        }
        if (TileMap.tiles[x, y] == 1 && White <1)
        {
            int RandomX = Random.Range(2, 16);
            int RandomY = Random.Range(2, 16);
            Instantiate(WhiteShrine, new Vector3(RandomX, RandomY, -1), Quaternion.identity);
            White += 1;
        }
    }

    /*void GenerateEnemies()
    {



        while (true)
        {
            
            if (EnemyCount <= 40 && TileMap.tiles[x, y] == 1)
            {


                int index = Random.Range(0, enemyTiles.Length);
                int RandomX = Random.Range(2, 21);
                int RandomY = Random.Range(2, 16);
                GameObject go = Instantiate(enemyTiles[index], new Vector3(RandomX, RandomY, -2), Quaternion.identity);
                EnemyCount += 1;

                
            }
            if (EnemyCount >= 40)
            {
                break;
            }










        }

    }*/


/*
void InitialiseList()
{
    //Clear our list gridPositions.
    gridPositions.Clear();

    //Loop through x axis (columns).
    for (int x = 1; x < mapSizeX - 1; x++)
    {
        //Within each column, loop through y axis (rows).
        for (int y = 1; y < mapSizeY - 1; y++)
        {
            //At each index add a new Vector3 to our list with the x and y coordinates of that position.
            gridPositions.Add(new Vector3(x, y, 0f));
        }
    }
}
Vector3 RandomPosition()
{
    //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
    int randomIndex = Random.Range(0, gridPositions.Count);

    //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
    Vector3 randomPosition = gridPositions[randomIndex];

    //Remove the entry at randomIndex from the list so that it can't be re-used.
    gridPositions.RemoveAt(randomIndex);

    //Return the randomly selected Vector3 position.
    return randomPosition;
}

void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
{
    //Choose a random number of objects to instantiate within the minimum and maximum limits
    int objectCount = Random.Range(minimum, maximum + 1);

    //Instantiate objects until the randomly chosen limit objectCount is reached
    for (int i = 0; i < objectCount; i++)
    {
        //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
        Vector3 randomPosition = RandomPosition();

        //Choose a random tile from tileArray and assign it to tileChoice
        GameObject tileChoice = enemyTiles[Random.Range(0, tileArray.Length)];

        //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
        Instantiate(tileChoice, randomPosition, Quaternion.identity);
    }
}
*/
public static int x, y;
    void GenerateMapData() {
        // Allocate our map tiles
        tiles = new int[mapSizeX, mapSizeY];
        
        

        // Initialize our map tiles to be grass
        for (x = 0; x < mapSizeX; x++) {
            for (y = 0; y < mapSizeY; y++) {
                tiles[x, y] = 1;
            }
        }



        // Make bottom Outer Walls
        for (x = 0; x <= 23; x++) {
            for (y = 0; y < 1; y++) {
                tiles[x, y] = 0;
            }
        }
        // Make Left Outer Walls
        for (x = 0; x <= 0; x++)
        {
            for (y = 0; y < 18; y++)
            {
                tiles[x, y] = 0;
            }
        }
        // Make top Outer Walls
        for (x = 0; x <= 23; x++)
        {
            for (y = 17; y < 18; y++)
            {
                tiles[x, y] = 0;
            }
        }
        // Make Right Outer Walls
        for (x = 23; x <= 23; x++)
        {
            for (y = 0; y < 18; y++)
            {
                tiles[x, y] = 0;
            }
        }
        for (x = 2; x <= 21; x++)
        {

        }
            
        // Make Randomly Generated Wall Tiles


        for (x = 2; x <= 21; x++)
        {
            for (y = 2; y < 16; y++)
            {
                if (WallCount < 80)
                {
                    if (Random.Range(0, 4) == 1)
                    {
                        WallCount += 1;
                        tiles[x, y] = 0;
                    }
                }
                if (WallCount > 80)
                {
                    break;
                }

                
            }
        }
        
        //Spawn enemies
        for (x = 2; x <= 21; x++)
        {
            for (y = 2; y < 16; y++)
            {     //makes sure not to spawn on Wall Tiles
                if (tiles[x, y] == 0)
                {

                    Debug.Log("WROMG PLACE ");


                }
                //spawns possible enemy tiles on floor tiles only
                if (tiles[x, y] == 1)
                {
                    int index = Random.Range(0, enemyTiles.Length);
                    int RandomX = Random.Range(2, 21);
                    int RandomY = Random.Range(2, 16);
                    Instantiate(enemyTiles[index], new Vector3(RandomX, RandomY + 0.3f, 0), Quaternion.identity);
                    EnemyCount += 1;

                }
                if (EnemyCount >= 30)
                {
                    break;
                }



            }
        }
    }

    


    public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY) {

		TileType tt = tileTypes[ tiles[targetX,targetY] ];

		if(UnitCanEnterTile(targetX, targetY) == false)
			return Mathf.Infinity;

		float cost = tt.movementCost;

		if( sourceX!=targetX && sourceY!=targetY) {
			// We are moving diagonally!  Fudge the cost for tie-breaking
			// Purely a cosmetic thing!
			cost += 0.001f;
		}

		return cost;

	}

	void GeneratePathfindingGraph() {
		// Initialize the array
		graph = new Node[mapSizeX,mapSizeY];

		// Initialize a Node for each spot in the array
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeY; y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}

		// Now that all the nodes exist, calculate their neighbours
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeY; y++) {
/*
				// This is the 4-way connection version:
				if(x > 0)
					graph[x,y].neighbours.Add( graph[x-1, y] );
				if(x < mapSizeX-1)
					graph[x,y].neighbours.Add( graph[x+1, y] );
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < mapSizeY-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );
                    */

				// This is the 8-way connection version (allows diagonal movement)
				// Try left
			if(x > 0) {
					graph[x,y].neighbours.Add( graph[x-1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x-1, y-1] );
					if(y < mapSizeY-1)
						graph[x,y].neighbours.Add( graph[x-1, y+1] );
				}

				// Try Right
				if(x < mapSizeX-1) {
					graph[x,y].neighbours.Add( graph[x+1, y] );
					if(y > 0)
						graph[x,y].neighbours.Add( graph[x+1, y-1] );
					if(y < mapSizeY-1)
						graph[x,y].neighbours.Add( graph[x+1, y+1] );
				}

				// Try straight up and down
				if(y > 0)
					graph[x,y].neighbours.Add( graph[x, y-1] );
				if(y < mapSizeY-1)
					graph[x,y].neighbours.Add( graph[x, y+1] );

				 // This also works with 6-way hexes and n-way variable areas (like EU4)
			}
		}
	}

	void GenerateMapVisual() {
		for(int x=0; x < mapSizeX; x++) {
			for(int y=0; y < mapSizeY; y++) {
				TileType tt = tileTypes[ tiles[x,y] ];
				GameObject go = (GameObject)Instantiate( tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity );

				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.x = x;
				ct.y = y;
				ct.map = this;
			}
		}
	}

	public Vector3 TileCoordToWorldCoord(int x, int y) {
		return new Vector3(x, y, 0);
	}

	public bool UnitCanEnterTile(int x, int y) {

		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.

		return tileTypes[ tiles[x,y] ].isWalkable;
	}

    public void GeneratePathTo(int x, int y) {
		// Clear out our unit's old path.
		//selectedUnit.GetComponent<Unit>().currentPath = null;

		if( UnitCanEnterTile(x,y) == false ) {
			// We probably clicked on a mountain or something, so just quit out.
			return;
		}

		Dictionary<Node, float> dist = new Dictionary<Node, float>();
		Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

		// Setup the "Q" -- the list of nodes we haven't checked yet.
		List<Node> unvisited = new List<Node>();
		
		Node source = graph[
		                    selectedUnit.GetComponent<Unit>().tileX, 
		                    selectedUnit.GetComponent<Unit>().tileY
		                    ];
		
		Node target = graph[
		                    x, 
		                    y
		                    ];
		
		dist[source] = 0;
		prev[source] = null;

		// Initialize everything to have INFINITY distance, since
		// we don't know any better right now. Also, it's possible
		// that some nodes CAN'T be reached from the source,
		// which would make INFINITY a reasonable value
		foreach(Node v in graph) {
			if(v != source) {
				dist[v] = Mathf.Infinity;
				prev[v] = null;
			}

			unvisited.Add(v);
		}

		while(unvisited.Count > 0) {
			// "u" is going to be the unvisited node with the smallest distance.
			Node u = null;

			foreach(Node possibleU in unvisited) {
				if(u == null || dist[possibleU] < dist[u]) {
					u = possibleU;
				}
			}

			if(u == target) {
				break;	// Exit the while loop!
			}

			unvisited.Remove(u);

			foreach(Node v in u.neighbours) {
				//float alt = dist[u] + u.DistanceTo(v);
				float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
				if( alt < dist[v] ) {
					dist[v] = alt;
					prev[v] = u;
				}
			}
		}

		// If we get there, the either we found the shortest route
		// to our target, or there is no route at ALL to our target.

		if(prev[target] == null) {
			// No route between our target and the source
			return;
		}

		List<Node> currentPath = new List<Node>();

		Node curr = target;

		// Step through the "prev" chain and add it to our path
		while(curr != null) {
			currentPath.Add(curr);
			curr = prev[curr];
		}

		// Right now, currentPath describes a route from out target to our source
		// So we need to invert it!

		currentPath.Reverse();

		selectedUnit.GetComponent<Unit>().currentPath = currentPath;
	}

}
