using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private Transform button;
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(5);
        Cursor.lockState = CursorLockMode.Confined;
        button.gameObject.SetActive(true);
    }

    private void Start()
    {
        button = transform.GetChild(1);
        button.gameObject.SetActive(false);
        StartCoroutine(wait());
    }
}
