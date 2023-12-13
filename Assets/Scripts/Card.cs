using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private bool keyPressReady;
    [SerializeField] private GameObject player, Etext;
    void Start()
    {
        keyPressReady = false;
    }

    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(player.transform.GetChild(1));
            transform.localPosition = Vector3.zero;
            Etext.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (true)
            {
                keyPressReady = true;
                Etext.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            keyPressReady = false;
            Etext.SetActive(false);
        }
    }
}
