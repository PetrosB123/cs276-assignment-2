using JetBrains.Annotations;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotSpin : MonoBehaviour
{
    [SerializeField] GameObject Slot;
    bool disabled = false;
    GameObject slot1;
    GameObject slot2;
    GameObject slot3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (disabled)
        {
            Destroy(slot1);
            Destroy(slot2);
            Destroy(slot3);
        }
    }

    void OnDestroy()
    {
        Destroy(slot1);
        Destroy(slot2);
        Destroy(slot3);
    }

}
