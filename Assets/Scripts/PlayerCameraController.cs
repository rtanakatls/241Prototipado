using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;

    void ChangeCamera(int index)
    {
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = 0;
        }
        virtualCameras[index].Priority = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger1"))
        {
            ChangeCamera(1);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger1"))
        {
            ChangeCamera(0);
        }
    }
}
