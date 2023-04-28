using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData_", menuName = "UnitData/Collectable")]
public class CollectableData : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField] private string _name = "Collectable";
    [SerializeField] private CollectableType _collectableType;
    [SerializeField] [Range(0, 100)] private int _value = 1;
}
