using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool midJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
       if(Input.GetKey(KeyCode.W)){
        inputVector += Vector2.up;
       }

        if(Input.GetKey(KeyCode.S)){
        inputVector += Vector2.down;
       }

        if(Input.GetKey(KeyCode.D)){
        inputVector += Vector2.right;
       }

        if(Input.GetKey(KeyCode.A)){
        inputVector += Vector2.left;
       }
       //if the ball is in mid air, it cannot jump.
        if(Input.GetKey(KeyCode.Space) && !midJump){
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            midJump = true;
        }
       Vector3 inputXZPlane = new Vector3(inputVector.x,0,inputVector.y);
       sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
       
    }
    //once the ball touches the floor, it may jump again.
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("floor")){
            midJump = false;
        }
    }
}
