using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float laserOffset = 0.5f;
    [SerializeField] private float playerSpeed = 10f;
    private Rigidbody2D playerRb;
    private float horizontalInput, verticalInput;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1")) {
            //Instantiate(laserPrefab, transform.position + Vector3.up * laserOffset, Quaternion.identity);
            GameObject laser = LaserPool.Instance.RequestLaser();
            laser.transform.position = transform.position + Vector3.up * laserOffset;
        }
    }

    private void FixedUpdate() {
        Vector2 movement = playerSpeed * Time.fixedDeltaTime * new Vector2(horizontalInput, verticalInput);
        playerRb.MovePosition(playerRb.position + movement);
    }
}