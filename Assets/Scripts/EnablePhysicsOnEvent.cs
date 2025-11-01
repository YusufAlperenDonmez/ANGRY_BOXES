using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhysicsOnEvent : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        UIButtonHandler.OnUIStartButtonPressed += StartPhyicsOnButtonPressed;
        rb.isKinematic = true;
    }

    private void StartPhyicsOnButtonPressed()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnDestroy()
    {
        UIButtonHandler.OnUIStartButtonPressed -= StartPhyicsOnButtonPressed;
    }
}
