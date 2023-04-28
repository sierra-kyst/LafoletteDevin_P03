using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableData _data;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

        }
    }
}
