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
    private float x = 60f;
    private float y = 579.7501f - 60;
    GameObject heart1;
    List<GameObject> heartsList = new List<GameObject> { };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (heartCount != player.GetComponent<Move>().hearts)
        {
            if (heartsList.Count() > 0)
            {
                for (int i = 0; i < heartsList.Count(); i++)
                {
                    Destroy(heartsList[i]);
                }
                heartsList.Clear();
            }
            UpdateHearts();
        }
    }

    void UpdateHearts()
    {
        heartCount = player.GetComponent<Move>().hearts;
        for (int i = 0; i < heartCount; i++)
        {
            heart1 = Instantiate(heart, new Vector3(x + 110 * i, y, 0), Quaternion.identity, parent: this.transform);
            heartsList.Add(heart1);
        }
    }
}
