using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerMainScreen : MonoBehaviour
{
    public Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseOver()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
