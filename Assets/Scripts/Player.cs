using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public LayerMask deathBoxLayer;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;

    public GameManager gameManager;

    private Rigidbody rb;
    private bool isGrounded;

    public float fallMultiplier = 5f;
    public float lowJumpMultiplier = 30f;

    private bool jumpRequest;

    [SerializeField]private AnimationCurve animCurve;
    [SerializeField]private float rotationTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
        mileStoneCount = mileStone;
    }

    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, -transform.up, 0.51f, groundLayer);

        bool dead = Physics.Raycast(transform.position, Vector3.down, 0.51f, deathBoxLayer);

        if(dead) {
            GameOver();
        }

        if(transform.position.x > mileStoneCount) {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
            Debug.Log("M"+mileStone+", "+"MC"+mileStoneCount+", MS"+speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
            
        }

        void GameOver() {
            gameManager.GameOver();
        }


    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

//      jos haluaa tehdä kulmassa olevia platformeja ni noita voi miettiä       I
//                                                                              V
//        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode.VelocityChange);
//        rb.velocity += transform.right * speed * Time.deltaTime;

        if (jumpRequest) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            jumpRequest = false;
        }

        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }

//      playerobjektin rotaatio platformin mukaan I
//                                                V

//    private void SurfaceAlignment() 
//    {
//            Ray ray = new Ray(transform.position, -transform.up);
//            RaycastHit info = new RaycastHit();

//        if (Physics.Raycast(ray, out info, groundLayer)) {
//            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), animCurve.Evaluate(rotationTime));
//        }
//    }

}
