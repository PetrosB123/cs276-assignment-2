using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour
{
    [SerializeField] Sprite[] slotSprites;
    [SerializeField] float timeBetweenSpins = .5f;
    private Sprite newSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(timeBetweenSpins);

            newSprite = slotSprites[Random.Range(0, slotSprites.Length)];

            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
