using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour

{
    [SerializeField]
    private Counter counter;

    [SerializeField]
    private float rotationSpeed = 30f;

    [SerializeField]
    private float fireForce = 1000f;

    [SerializeField]
    private GameObject cannonBallPrefab;

    [SerializeField]
    private List<GameObject> cannonBallAmmo;

    private GameObject cannonBallSpawn;
    private GameObject cannonBase;
    private bool hasFired = false;
    private float fireDelay = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        cannonBallSpawn = transform.Find("Spawn").gameObject;
        cannonBase = GameObject.Find("CannonYRot").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalRotationAmount = verticalInput * rotationSpeed * Time.deltaTime;
        float horizontalRotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, verticalRotationAmount);
        cannonBase.transform.Rotate(cannonBase.transform.up, horizontalRotationAmount);

        if (Input.GetButton("Fire1") && !hasFired)
        {
            FireCanonball();
            hasFired = true;

            StartCoroutine(ResetHasFired());
        }
    }

    private void FireCanonball()
    {
        if(cannonBallAmmo.Count > 0)
        {
            // GameObject cannonBall = Instantiate(cannonBallPrefab, cannonBallSpawn.transform.position, cannonBallSpawn.transform.rotation);
            GameObject poppedCannonBall = cannonBallAmmo[cannonBallAmmo.Count - 1];
            cannonBallAmmo.RemoveAt(cannonBallAmmo.Count - 1);
            poppedCannonBall.transform.position = cannonBallSpawn.transform.position;

            Rigidbody rb = poppedCannonBall.GetComponent<Rigidbody>();
            rb.AddForce(cannonBallSpawn.transform.up * fireForce);
        } else
        {
            GameOver();
        }
       
    }

    private IEnumerator ResetHasFired()
    {
        yield return new WaitForSeconds(fireDelay);
        hasFired = false;
    }

    private void GameOver()
    {
        ScoreManager.Instance.roundOver(counter.Count);
    }
}
