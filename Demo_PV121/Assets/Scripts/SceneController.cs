using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private System.Random _rnd = new System.Random();
    [SerializeField]
    private GameObject TargetPrefab;

    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            _target = Instantiate(TargetPrefab) as GameObject;
            _target.transform.position = new Vector3(_rnd.Next(-90, 90), 4, _rnd.Next(-90, 90));
        }
    }
}
