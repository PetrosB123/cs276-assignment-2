using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UIElements;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject heart;
    GameObject player;
    private float heartCount;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    List<GameObject> heartsList = new List<GameObject> { };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heartCount = player.GetComponent<Move>().hearts;
        if (heartCount >= 1)
        {
            heart1.SetActive(true);
        }
        if (heartCount >= 2)
        {
            heart2.SetActive(true);
        }
        if (heartCount >= 3)
        {
            heart3.SetActive(true);
        }
    }
}
