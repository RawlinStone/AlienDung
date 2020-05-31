using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public SpriteRenderer renderer;
    public bool hurt;
    public float hurtTime;
    private float hurtCounter;
    public GameManager gm;
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        hurt = false;
        renderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            
            if (this.gameObject.name == "Player1Sprite")
            {

                gm.player1Alive = false;
                this.gameObject.SetActive(false);
            }
            if (this.gameObject.name == "Player2Sprite")
            {
                gm.player2Alive = false;
                this.gameObject.SetActive(false);
            }
            
                
        }
        if(hurt)
        {
            if(hurtCounter > hurtTime * .66f)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
            }
            else if(hurtCounter > hurtTime * .33f)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
            }
            else if(hurtCounter > 0f)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
            }

            else
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
                hurt = false;
            }
            hurtCounter -= Time.deltaTime;
        }
       
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
        hurt = true;
        hurtCounter = hurtTime;
        audio.Play();

        
    }

    public void PlayerGainHealth(int healthGain)
    {
        int temp = health;
        temp += healthGain;
        if(temp > 100)
        {
            health = 100;
        }
        else
        {
            health += healthGain;
        }
    }


}
