using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCodeBox : MonoBehaviour
{
    private bool keyPressReady, padOpen, boxOpened, escapeDisabled;
    [SerializeField] private GameObject playerCamera, Etext, keyPad;
    [SerializeField] private Animator boxAnim;
    void Start()
    {
        keyPressReady = false;
        padOpen = false;
        boxOpened = false;
        escapeDisabled = false;
        keyPad = playerCamera.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E) & !boxOpened)
        {
            padOpen = true;
        }

        if (padOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            playerCamera.GetComponent<MouseLook>().enabled = false;
            keyPad.SetActive(true);
            Etext.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape) & !escapeDisabled)
            {
                padOpen = false;
            }
        } else if (!padOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerCamera.GetComponent<MouseLook>().enabled = true;
            keyPad.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") & !boxOpened)
        {
            if (true)
            {
                keyPressReady = true;
                if (!padOpen) 
                {
                    Etext.SetActive(true);
                }
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

    public void boxOpen()
    {
        boxOpened = true;
        StartCoroutine(boxOpening());
    }

    IEnumerator boxOpening()
    {
        yield return new WaitForSecondsRealtime(1);
        padOpen = false;
        boxAnim.SetBool("boxOpen", true);
    }

    public void accessDeny()
    {
        escapeDisabled = true;
        StartCoroutine(accessDenied());
    }

    IEnumerator accessDenied()
    {
        yield return new WaitForSecondsRealtime(1);
        escapeDisabled = false;
    }
}
