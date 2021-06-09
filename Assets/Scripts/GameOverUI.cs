using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    

    public Text fruitText;
    public Text junkText;
    public Text vegText;
    // Start is called before the first frame update
    void Start()
    {
        fruitText.text = Player.fruitScore.ToString();
        junkText.text = Player.junkScore.ToString();
        vegText.text = Player.vegScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
