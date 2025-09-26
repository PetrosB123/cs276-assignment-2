using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Roll : MonoBehaviour
{
    [SerializeField] float rollSpeed = 500f;
    [SerializeField] public Sprite[] diceSprites;
    String rolling = "";
    private delegate void rollingMethod();
    rollingMethod roll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (UnityEngine.Random.Range(0, 1) == 0)
        {
            roll = RollBackward;
        }
        else
        {
            roll = RollForward;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = diceSprites[UnityEngine.Random.Range(0, 6)];
    }

    void Update()
    {
        roll();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("DiceSurface"))
        {
            if (rolling == "forward")
            {
                roll = RollBackward;
            }
            else
            {
                roll = RollForward;
            }
        }
    }

    void RollForward()
    {
        transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        rolling = "forward";
    }
    void RollBackward()
    {
        transform.Rotate(-Vector3.forward * rollSpeed * Time.deltaTime);
        rolling = "backward";
    }
}
