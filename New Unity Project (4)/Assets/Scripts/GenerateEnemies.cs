
using System.Collections;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class GenerateEnemies : MonoBehaviour
{
    public TileType[] tileTypes;
    public int EnemyCount;
    public GameObject[] enemyTiles;
    public static int[,] tiles;
    public GameObject selectedUnit;
    public Transform enemy1;
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = .25f;
    public float timeBeforeWaves = 2.0f;


    public int enemiesPerWave = 30;
    public int currentNumberOfEnemies = 0;


    /*  void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Enemy")
         {
             Destroy (other); 
         }
     }
    */




    /*void Enemies()
    {
        // Give the player time before we start the game


        // After timeBeforeSpawning has elapsed, we will enter this loop
        while (true)
        {
            // Don't spawn anything new until all the previous
            // wave's enemies are dead
            if (EnemyCount <= 0)
            {
                float randDirection;
                float randDistance;

                //Spawn 10 enemies in a random position
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // We want the enemies to be off screen
                    // (Random.Range gives us a number between the 
                    // first and second parameter)
                    randDistance = Random.Range(10, 25);

                    // Enemies can come from any direction
                    randDirection = Random.Range(0, 360);

                    // Using the distance and direction we set the position
                    float posX = this.transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * randDistance);
                    float posY = this.transform.position.y + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * randDistance);

                    // Spawn the enemy and increment the number of 
                    // enemies spawned 
                    // (Instantiate Makes a clone of the first parameter 
                    // and places it at the second with a rotation of 
                    // the third.)
                    Instantiate(enemyTiles, new Vector3(posX, posY, 0), this.transform.rotation);
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            // How much time to wait before checking if we need to 
            // spawn another wave
            yield return new WaitForSeconds(timeBeforeWaves);

         Debug.Log("Spawn!");
                for (x = 2; x <= 20; x++)
                {
                    for (y = 2; y < 15; y++)
                    {

                        if (EnemyCount < 25)
                        {
                            if (TileMap.tiles[x, y] == 1 && Random.Range(0, 9) == 1)
                            {

                                Debug.Log("Spawn!");
                                Instantiate(enemyTiles[index], new Vector3(x, y, 0), Quaternion.identity);

                                EnemyCount += 1;
        }
    }
    */


    void Start()
    {
       

        
        while (true)
        {
            int x = TileMap.x;
            int y = TileMap.y;
            if (EnemyCount <= 30 && TileMap.tiles[x, y] == 1)
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


            


