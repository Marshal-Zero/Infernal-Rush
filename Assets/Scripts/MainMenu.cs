using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem startGame;
    [SerializeField]
    public float timeLeft;

    private void Awake()
    {
        //startGame.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameStarted == true)
        {
            Destroy(startGame);
        }
    }

    }


