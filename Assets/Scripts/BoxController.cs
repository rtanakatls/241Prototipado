using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject currentBox;


    void Update()
    {
        if (currentBox == null)
        {
            currentBox=Instantiate(boxPrefab);
            currentBox.transform.position = transform.position;
            
        }
    }
}
