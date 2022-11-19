using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Player position")]
    [SerializeField] private GameObject _player;

    void Update()
    {
        if (_player.transform.position.y>3)
        {
            if (_player.transform.position.y > transform.position.y + 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 4f * Time.deltaTime, transform.position.z);
            }
            else if (_player.transform.position.y < transform.position.y - 1) 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 4f * Time.deltaTime, transform.position.z);
            }
            
        }        

    }
}
