using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public bool hasCard;
    [SerializeField] private Transform player;

    void Start()
    {
        hasCard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetChild(1).transform.childCount >= 1)
        {
            hasCard = true;
        }

    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
