using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runes : MonoBehaviour
{
    public int runes = 0;
    public Text runesText;

    void Update()
    {
        runesText.text = " " + runes;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            runes++;
        }
    }
}
