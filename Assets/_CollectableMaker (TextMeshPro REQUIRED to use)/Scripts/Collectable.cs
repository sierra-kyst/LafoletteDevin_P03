using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableData _data;
    //private Powerup _powerup; //MAKE SEPARATE SCRIPT FOR POWERUP(S)
    //private Item _item; //MAKE SEPARATE SCRIPT FOR ITEM PICKUP(S)
    [SerializeField] private GameObject _artToDisable = null;
    private Collider _collider;

    private bool timerOn = false;
    private int timer = 0;

    public Player _player;

    private void Awake()
    {
        //_powerup = GetComponent<Powerup>();
        //_item = GetComponent<Item>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _player = GetComponent<Player>();
        if (other.gameObject.tag=="Player")
        {
            if (_data._collectableType == CollectableType.Currency)
            {
                _player.currencyCollect(_data._value);
            }
            else if (_data._collectableType == CollectableType.Health)
            {
                _player.Heal(_data._value);
            }
            else if (_data._collectableType == CollectableType.Ammo)
            {
                _player.IncreaseAmmo(_data._value);
            }
            else if (_data._collectableType == CollectableType.Bonus)
            {
                _player.bonusCollect(_data._value);
            }
            else if (_data._collectableType == CollectableType.Powerup)
            {
                //_powerup.Activate();
            }
            else if (_data._collectableType == CollectableType.Item)
            {
                //_item.Equipped();
            }
            if (_data._soundEffect != null)
            {
                AudioSource newSound = Instantiate(_data._soundEffect, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
            if (_data._pickupParticle != null)
            {
                var particle = Instantiate(_data._pickupParticle, transform.position, transform.rotation);
                Destroy(particle.gameObject, 1);
            }
            _artToDisable.SetActive(false);
            _collider.enabled = false;
            Debug.Log(_data._collectableType.ToString() + " get!");
            if (_data.timer == true)
            {
                timerOn = true;
            }
        }
    }

    //This is for testing and can be deleted/commented out once testing is complete
    //Just remember to copy/paste all code from "if(_type == CollectableType.Currency)" to "_collider.enabled = false;" into OnTriggerEnter before deleting :)
    private void OnMouseOver()
    {
        //PASTE OnTriggerEnter() code IN HERE
        if (Input.GetMouseButtonDown(0))
        {
            if (_data._collectableType == CollectableType.Currency)
            {
                _player.currencyCollect(_data._value);
            }
            else if (_data._collectableType == CollectableType.Health)
            {
                _player.Heal(_data._value);
            }
            else if (_data._collectableType == CollectableType.Ammo)
            {
                _player.IncreaseAmmo(_data._value);
            }
            else if (_data._collectableType == CollectableType.Bonus)
            {
                _player.bonusCollect(_data._value);
            }
            else if (_data._collectableType == CollectableType.Powerup)
            {
                //_powerup.Activate();
            }
            else if (_data._collectableType == CollectableType.Item)
            {
                //_item.Equipped();
            }
            if (_data._soundEffect != null)
            {
                AudioSource newSound = Instantiate(_data._soundEffect, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
            if (_data._pickupParticle != null)
            {
                var particle = Instantiate(_data._pickupParticle, transform.position, transform.rotation);
                Destroy(particle.gameObject, 1);
            }
            _artToDisable.SetActive(false);
            _collider.enabled = false;
            Debug.Log(_data._collectableType.ToString() + " get!");
            if(_data.timer == true)
            {
                timerOn = true;
            }
        }
    }

    private void Update()
    {
        if(timerOn)
        {
            timer++;
            if(timer >= _data.timerDuration)
            {
                _artToDisable.SetActive(true);
                _collider.enabled = true;
                timerOn = false;
                timer = 0;
            }
        }
    }
}
