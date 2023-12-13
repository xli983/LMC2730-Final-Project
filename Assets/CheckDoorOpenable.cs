using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoorOpenable : MonoBehaviour
{
    private bool keyPressReady;
    [SerializeField] private GameObject player, Etext;
    [SerializeField] private Animator anim;
    private SceneTransfer sceneTransfer;
    void Start()
    {
        keyPressReady = false;
        sceneTransfer = UnityEngine.Object.FindObjectsOfType<SceneTransfer>()[0];
    }

    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E) & !sceneTransfer.hasCard)
        {
            anim.SetBool("IsPlayerClose", true);
        } else if (keyPressReady & Input.GetKeyDown(KeyCode.E) & sceneTransfer.hasCard)
        {
            sceneTransfer.NextScene();
        } else if (!keyPressReady & anim.GetBool("IsPlayerClose"))
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
