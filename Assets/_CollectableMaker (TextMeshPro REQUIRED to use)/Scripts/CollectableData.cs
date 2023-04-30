using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData_", menuName = "UnitData/Collectable")]
public class CollectableData : ScriptableObject
{
    [Header("General Stats")]
    [SerializeField] private string _name = "Collectable";
    [SerializeField] public CollectableType _collectableType;
    [SerializeField] [Tooltip("If =Powerup, value = seconds Powerup is active for Player")] [Range(0, 100)] public int _value = 1;
    [SerializeField] [Tooltip("If checked, collectable reappears after collided with")] public bool timer = false;
    [SerializeField] [Tooltip("How long the collectable is gone after it is collided with")] [Range(0, 1000)] public int timerDuration = 100;

    [Header("VFX & SFX")]
    [SerializeField] [Tooltip("Plays sound when collected by Player")] public AudioSource _soundEffect;
    [SerializeField] [Tooltip("Creates particle effect for when Player picks up collectable")] public ParticleSystem _pickupParticle;
}
