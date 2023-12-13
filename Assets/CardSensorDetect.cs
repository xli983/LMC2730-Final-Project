using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSensorDetect : MonoBehaviour
{
    private SceneTransfer sceneTransfer;
    [SerializeField] private GameObject door1, door2;
    private Light sensor;
    // Start is called before the first frame update
    void Start()
    {
        sceneTransfer = UnityEngine.Object.FindObjectsOfType<SceneTransfer>()[0];
        sensor = transform.GetChild(0).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneTransfer.hasCard)
        {
            if (door1 != null)
            {
                door1.SetActive(false);
                door2.SetActive(true);
            }
            sensor.color = Color.green;
        }
    }
}
