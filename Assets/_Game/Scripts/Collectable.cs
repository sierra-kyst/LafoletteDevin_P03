using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableData _data;
    private Player _player;
    //private Powerup _powerup; //MAKE SEPARATE SCRIPT FOR POWERUP(S)
    //private Item _item; //MAKE SEPARATE SCRIPT FOR ITEM PICKUP(S)
    [SerializeField] private GameObject _artToDisable;
    [SerializeField] private Collider _collider;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
        //_powerup = GetComponent<Powerup>();
        //_item = GetComponent<Item>();
        _artToDisable = GameObject.FindGameObjectWithTag("Art").GetComponent<GameObject>();
        _collider = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            if(_data._collectableType == CollectableType.Currency)
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
            _artToDisable.SetActive(false);
            _collider.enabled = false;
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
            _artToDisable.SetActive(false);
            _collider.enabled = false;
        }
    }
}
