using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBallLogic : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float ballForwardForce = 500f;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        UIButtonHandler.OnUIShootButtonPressed += ShootBallOnButtonPressed;
    }

    private void ShootBallOnButtonPressed()
    {
        if (ballPrefab == null)
        {
            Debug.LogWarning("ShootBallLogic: ballPrefab is not assigned.");
            return;
        }

        if (mainCam == null)
        {
            mainCam = Camera.main;
            if (mainCam == null)
            {
                Debug.LogWarning("ShootBallLogic: No camera found to spawn balls from.");
                return;
            }
        }

        Vector3 spawnPosition = mainCam.transform.position + mainCam.transform.forward * 0.1f;
        Quaternion spawnRotation = mainCam.transform.rotation;

        GameObject spawnBall = Instantiate(ballPrefab, spawnPosition, spawnRotation);
        Rigidbody rb = spawnBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply forward force multiplied by configured magnitude
            rb.AddForce(mainCam.transform.forward * ballForwardForce);
        }

        Destroy(spawnBall, 5f);
    }

    private void OnDestroy()
    {
        UIButtonHandler.OnUIShootButtonPressed -= ShootBallOnButtonPressed;
    }
}
