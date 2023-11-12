using UnityEngine;

public class GrapplingHook : MonoBehaviour
{ //class

    private Vector3 direction;
    private PlayerController playerController;

    [SerializeField] Camera mainCamera;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] DistanceJoint2D distanceJoint;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float grappleSpeed = 0.5f;

    public Transform linePosition;
    public bool isGrappling;
    public Transform lookToHook;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }//awake

    private void Start()
    {
        InitHook();
    }//start

    private void Update()
    {
        direction = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (!playerController.IsGrounded())
        {
           Grapple(direction);
        }
        else
        {
            DisableHook();
        }

    }//update

    private void Grapple(Vector3 direction)
    {
        if (isGrappling)
        {
            //creates are rope where the mouse is clicked
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector2 hookAnchorPoint = (Vector2)direction;

                lineRenderer.SetPosition(0, hookAnchorPoint); // acnhor

                distanceJoint.connectedAnchor = hookAnchorPoint; //makes a line between points
                distanceJoint.enabled = true;

                linePosition.position = hookAnchorPoint;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                lineRenderer.SetPosition(1, transform.position);
                lineRenderer.enabled = true;

            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                DisableHook();
            }

            //moves the player towards the anchor point
            Vector2 playerPos = Vector2.MoveTowards(transform.position, linePosition.position, grappleSpeed * Time.deltaTime);
            transform.position = playerPos;
            
        }

    }//grapple

    private void InitHook()
    {
        isGrappling = true;
        distanceJoint.autoConfigureDistance = true;
        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
    }//initHook

    private void DisableHook()
    {
        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
    }

}//class
