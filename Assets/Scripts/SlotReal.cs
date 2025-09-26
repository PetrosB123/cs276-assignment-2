using UnityEngine;
using System.Collections;
using System;

public class SlotReal : MonoBehaviour
{
    [SerializeField] public Sprite[] slotSprites;
    [SerializeField] float timeBetweenSpins = .25f;
    public String type = "";
    private Sprite newSprite;
    public bool finished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        while (timeBetweenSpins < 2)
        {
            yield return new WaitForSecondsRealtime(timeBetweenSpins);
            int rand = UnityEngine.Random.Range(0, slotSprites.Length);
            newSprite = slotSprites[rand];

            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

            timeBetweenSpins += .25f * timeBetweenSpins;

            if (rand == 0)
            {
                type = "coin";
            }
            else if (rand == 1)
            {
                type = "heart";
            }
            else if (rand == 2)
            {
                type = "speed";
            }
            else if (rand == 3)
            {
                type = "bomb";
            }
        }
        finished = true;
    }
}
