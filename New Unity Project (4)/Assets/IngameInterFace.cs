using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngameInterFace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
   private bool ISMOUSEOVERUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
