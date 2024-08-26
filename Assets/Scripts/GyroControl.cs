using UnityEngine;

public class GyroControl:MonoBehaviour {
  public float speed = 10f;
  public float smoothTime = 0.3f; // Time it takes to smooth the movement
  private Rigidbody rb;
  private Vector3 currentVelocity = Vector3.zero;
  [SerializeField] ForceMode forceMode = ForceMode.Acceleration;

  void Start() {
    // Enable the gyroscope
    Input.gyro.enabled = true;

    // Get the Rigidbody component
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    float tiltX;
    float tiltY;

#if UNITY_EDITOR
        tiltX = Input.GetAxis("Horizontal");
        tiltY = Input.GetAxis("Vertical");
#else
    tiltX = Input.gyro.gravity.x;
    tiltY = Input.gyro.gravity.y;
#endif

    Vector3 targetMovement = new Vector3(tiltX,0.0f,tiltY);
    Vector3 smoothMovement = Vector3.SmoothDamp(rb.velocity,targetMovement * speed,ref currentVelocity,smoothTime);

    rb.AddForce(smoothMovement - rb.velocity,forceMode);
  }
}
