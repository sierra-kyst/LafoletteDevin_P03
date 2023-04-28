using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField] private string _name;
    [SerializeField] private CollectableType _collectableType;
    [SerializeField] [Range(0,100)] private int _value;
}
