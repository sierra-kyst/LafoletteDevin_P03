using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData_", menuName = "UnitData/Collectable")]
public class CollectableData : ScriptableObject
{
    [Header("General Stats")]
    //[SerializeField] private string _name = "Collectable";
    [SerializeField] public CollectableType _collectableType;
    [SerializeField] [Tooltip("If =Powerup, value = seconds Powerup is active for Player")] [Range(0, 100)] public int _value = 1;
    [SerializeField] [Tooltip("Plays when collected by Player")] public AudioSource _soundEffect;
}
