using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private bool keyPressReady;
    public GameObject teleportRoom;
    public GameObject player;
    void Start()
    {
        keyPressReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(player.transform.GetChild(1));
            transform.localPosition = Vector3.zero;
            player.transform.position = new Vector3(teleportRoom.transform.position.x, teleportRoom.transform.position.y + 3, teleportRoom.transform.position.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (true)
            {
                keyPressReady = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            keyPressReady = false;
        }
    }
}
