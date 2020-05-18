using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

    public int tileX;
    public int tileY;
    public TileMap map;

    public int gold;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int MaxXP = 25;
    public int currentXP;
    public XPbAR XPBar;

    public int MaxStamina = 25;
    public int currentStamina;
    public StaminaBar staminaBar;

    public int MaxShield = 50;
    public int currentShield;
    public ShieldBar shieldbar;

    public float moveTime = 10.0f; 
    public List<Node> currentPath = null;

    int moveSpeed = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            MoveNextTile();
       if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (currentPath != null)
        {

            int currNode = 0;

            while (currNode < currentPath.Count - 1)
            {

                Vector3 start = map.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y) +
                    new Vector3(0, 0, -1f);
                Vector3 end = map.TileCoordToWorldCoord(currentPath[currNode + 1].x, currentPath[currNode + 1].y) +
                    new Vector3(0, 0, -1f);

                Debug.DrawLine(start, end, Color.red);

                currNode++;
            }

            
        }
    }

    
    void OnTrigger2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage(25);

            

            Debug.Log("PLAYER DETECTION MF");
        }

        if (collision.tag == "BlackSpace")
        {
           
            Debug.Log("Gave Player Health");
        }
    }
    


    void GiveHealth(int Health)
    {
        if (currentShield <= 0)
        {
            currentHealth += Health;

            healthBar.SetHealth(currentHealth);
        }
        if (currentShield >= 0)
        {
            currentShield += Health;

            shieldbar.SetShield(currentShield);


        }
    }

    void TakeDamage(int Damage)
        {
        if (currentShield <= 0)
        {
            currentHealth -= Damage;

            healthBar.SetHealth(currentHealth);
        }
        if (currentShield >= 0)
        {
            currentShield -= Damage;

            shieldbar.SetShield(currentShield);

            
        }
        
    }
    void TakeStaminaDamage(int StaminaDecrease)
    {
        currentShield -= StaminaDecrease;

        staminaBar.SetStamina(currentStamina);

    }

    void GiveXP(int XPIncrease)
    {
        currentXP -= XPIncrease;

        XPBar.SetMaxXP(currentXP);

    }
    void Start()
    {
        currentXP = 0;
        XPBar.SetMaxXP(MaxXP);
        currentStamina = MaxStamina;
        staminaBar.SetMaxStamina(MaxStamina);
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
        currentShield = MaxShield;
        shieldbar.SetMaxShield(MaxShield);
        gold = 0; 
    }

  
    public void MoveNextTile()
    {
        float remainingMovement = moveSpeed;

        while (remainingMovement > 0)
        {
            if (currentPath == null)
                return;
           
            // Get cost from current tile to next tile
            remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y);

            // Move us to the next tile in the sequence
            tileX = currentPath[1].x;
            tileY = currentPath[1].y;

            float step = moveTime * Time.deltaTime;
            //transform.position = Vector3.Lerp(tileX, tileY, step);
          transform.position = map.TileCoordToWorldCoord(tileX, tileY);   // Update our unity world position

            // Remove the old "current" tile
            currentPath.RemoveAt(0);

            if (currentPath.Count == 1)
            {
                // We only have one tile left in the path, and that tile MUST be our ultimate
                // destination -- and we are standing on it!
                // So let's just clear our pathfinding info.
                currentPath = null;
            }
        }

    }
   
}
