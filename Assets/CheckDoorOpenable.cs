using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoorOpenable : MonoBehaviour
{
    private bool keyPressReady;
    [SerializeField] private GameObject player, Etext;
    [SerializeField] private Animator anim;
    void Start()
    {
        keyPressReady = false;
    }

    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("IsPlayerClose", true);
        } 
        else if (!keyPressReady & anim.GetBool("IsPlayerClose"))
        {
            StartCoroutine(DoorClose());
        }
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSecondsRealtime(3);
        anim.SetBool("IsPlayerClose", false);
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
