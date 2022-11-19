using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    [Header("Player position")]
    [SerializeField] private GameObject _player;
    [SerializeField] private Text _winText;

    void Update()
    {
        if (_player.transform.position.y > transform.position.y )
        {
            _winText.text = "онаедю!"; 
        }
    }
}
