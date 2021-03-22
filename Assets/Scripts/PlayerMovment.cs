using UnityEngine;

public class PlayerMovment : MonoBehaviour {
    public float speed;
    public float xMult;
    public Rigidbody _rb;

    private float xInput;
    private float xStep = 0.0f;
    private bool isAlive = true;

    private float step = 4.5f;
    
    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            xStep -= step;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            xStep += step;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            isAlive = false;
            Debug.Log("Game over!");
        }
    }

    private void FixedUpdate() {
        Vector3 zMove = transform.forward * speed * Time.fixedDeltaTime;
        // Vector3 xMove = transform.right * xInput * xMult * speed * Time.fixedDeltaTime;

        

        Vector3 newMove = new Vector3(xStep, _rb.position.y, _rb.position.z);        


        if (isAlive) {
            //_rb.MovePosition(_rb.position + zMove + xMove);
            _rb.MovePosition(newMove + zMove);
        }
    }

}
