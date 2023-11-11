using UnityEngine;

public class Ground : MonoBehaviour
{ //class

    private MeshRenderer meshRenderer;
    // makes the background move slower than the ground
    [SerializeField] float speedOffSet = 1.0f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
       float speed = GameManager.Instance.gameSpeed / transform.localScale.x / speedOffSet;

        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }

} //class
