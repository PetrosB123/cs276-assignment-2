using System;
using JetBrains.Annotations;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Runtime.CompilerServices;

public class SlotSpinReal : MonoBehaviour
{
    [SerializeField] GameObject Slot;
    [SerializeField] ParticleSystem boom;
    [SerializeField] Sprite broken;
    GameObject player;
    GameObject slot1;
    GameObject slot2;
    GameObject slot3;
    private String bonus;
    [SerializeField] AudioSource ding;
    [SerializeField] AudioSource womp;
    [SerializeField] AudioSource explode;
    private bool finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        float pixelSize = .0625f;
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        float slot1x = x - 1 * pixelSize;
        float slot1y = y + 2 * pixelSize;
        float slot2x = slot1x - 3 * pixelSize;
        float slot2y = slot1y;
        float slot3x = slot1x + 3 * pixelSize;
        float slot3y = slot1y;

        slot1 = Instantiate(Slot, new Vector3(slot1x, slot1y, 0), Quaternion.identity);
        slot2 = Instantiate(Slot, new Vector3(slot2x, slot2y, 0), Quaternion.identity);
        slot3 = Instantiate(Slot, new Vector3(slot3x, slot3y, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (slot1)
        {
            if (slot1.GetComponent<SlotReal>().finished && slot2.GetComponent<SlotReal>().finished && slot3.GetComponent<SlotReal>().finished && !finished)
            {
                string slot1type = slot1.GetComponent<SlotReal>().type;
                string slot2type = slot2.GetComponent<SlotReal>().type;
                string slot3type = slot3.GetComponent<SlotReal>().type;

                if (slot1type == slot2type || slot1type == slot3type)
                {
                    bonus = slot1type;
                }
                else if (slot2type == slot3type)
                {
                    bonus = slot2type;
                }
                else
                {
                    bonus = "none";
                }

                switch (bonus)
                {
                    case "coin":
                        Debug.Log("Coin");
                        player.GetComponent<Move>().score += 5;
                        break;
                    case "heart":
                        Debug.Log("Heart");
                        if (player.GetComponent<Move>().hearts < 3)
                        {
                            player.GetComponent<Move>().hearts += 1;
                        }
                        else
                        {
                            player.GetComponent<Move>().score += 1;
                        }
                        break;
                    case "speed":
                        Debug.Log("Speed");
                        StartCoroutine(Boost());
                        break;
                    case "bomb":
                    explode.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                        explode.Play();
                        Destroy(slot1);
                        Destroy(slot2);
                        Destroy(slot3);
                        gameObject.GetComponent<SpriteRenderer>().sprite = broken;
                        Instantiate(boom.gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
                        break;
                    case "none":
                        womp.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                        womp.Play();
                        break;

                }
                if (bonus != "bomb" && bonus != "none")
                {
                    ding.pitch = UnityEngine.Random.Range(1f, 1.2f);
                    ding.Play();
                }
                finished = true;
            }
        }
    }

    IEnumerator Boost()
    {
        player.GetComponent<Move>().currSpeed = 2 * player.GetComponent<Move>().moveSpeed;
        yield return new WaitForSecondsRealtime(10);
        player.GetComponent<Move>().currSpeed = player.GetComponent<Move>().moveSpeed;
    }

}
