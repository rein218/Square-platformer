using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaterLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Timer")]
    [SerializeField] private float _timeDelay = 0;
    [SerializeField] private float _speedUp = 2f;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _startHight = 10f;

    void Update()
    {
        _timeDelay += 1*Time.deltaTime;
        if (_player.transform.position.y>_startHight && transform.position.y < 75)
        {
            transform.Translate(Vector2.up * (0.001f*(_speedUp + 3 * _timeDelay / 5)));
        }
        if (_player.transform.position.y < transform.position.y + 15.5 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
