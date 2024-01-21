using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;



public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float obstacleRange = 5.0f;
    private bool _alive = true;
    public bool Alive { get { return _alive; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit) && hit.distance < obstacleRange)
            {
                transform.Rotate(0, Random.Range(-110, 110), 0);
            }
        }
    }

    public void SetAlive(bool alive = true)
    {
        _alive = alive;
    }
    public void Kill()
    {
        SetAlive(false);
    }
}
