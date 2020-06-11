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
    public int totalEnemies;
    public GameObject closedDoor;
    public GameObject openDoorL;
    public GameObject openDoorR;
    public GameObject openDoorUp;
    
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
        if(totalEnemies <= 0)
        {
            closedDoor.SetActive(false);
            openDoorL.SetActive(true);
            openDoorR.SetActive(true);
            openDoorUp.SetActive(true);
            //set the closed door inactive
            //set open door active
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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
