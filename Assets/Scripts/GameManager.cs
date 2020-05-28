using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public bool player1Alive;
    public bool player2Alive;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        player1Alive = true;
        player2Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player1Alive && !player2Alive)
        {
            panel.SetActive(true);
        }
    }

    public void GameOver()
    {
        panel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
