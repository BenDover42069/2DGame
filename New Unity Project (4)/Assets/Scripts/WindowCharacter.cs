﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCharacter : MonoBehaviour
{
    
   
    public Transform player;

    private void Update()
    {
         transform.position = new Vector3(player.position.x, player.position.y -0.3f, Camera.main.transform.position.z);
    }
  

  
}
