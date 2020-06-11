using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public Text ammop1;
    public Text ammop2;
    public int p1startammo;
    public int p2startammo;
    public GameObject Player1;
    public GameObject Player2;
    private int player1Ammo;
    private int player2Ammo;
    public Text enemiesText;


    // Start is called before the first frame update
    void Start()
    {
        player1Alive = true;
        player2Alive = true;
        p1startammo = 20;
        p2startammo = 20;
        ammop1.text = "" + p1startammo;
        ammop2.text = "" + p2startammo;
        enemiesText.text = "X" + totalEnemies;
        player1Ammo = Player1.GetComponent<PlayerAmmoScript>().ammo;
        player2Ammo = Player2.GetComponent<PlayerAmmoScript>().ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1Alive && !player2Alive)
        {
            panel.SetActive(true);
        }
        if (totalEnemies <= 0)
        {
            closedDoor.SetActive(false);
            openDoorL.SetActive(true);
            openDoorR.SetActive(true);
            openDoorUp.SetActive(true);
            //set the closed door inactive
            //set open door active
        }
        player1Ammo = Player1.GetComponent<PlayerAmmoScript>().ammo;
        player2Ammo = Player2.GetComponent<PlayerAmmoScript>().ammo;
        ammop1.text = "" + player1Ammo;
        ammop2.text = "" + p2startammo;
        if (totalEnemies <= 0)
        {
            totalEnemies = 0;
        }
        enemiesText.text = "X" + totalEnemies;
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
