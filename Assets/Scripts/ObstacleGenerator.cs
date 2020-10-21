using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    CactusTouch cactusBig;

    [SerializeField]
    CactusTouch cactusSmall;

    Rigidbody2D rb2d;
    public float cactusInitDistance = 20;
    public float cactusDestroyDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateCactus();
        DeleteCactus();
    }

    void GenerateCactus()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, cactusInitDistance);
        if (rb2d.IsTouchingLayers(LayerMask.GetMask("Platform")) && hit.collider == null)
        {
            int size = Random.Range(0, 2);
            if (size == 1)
                Instantiate(cactusBig, new Vector2(transform.position.x + cactusInitDistance, 1.2f), Quaternion.identity);
            else
                Instantiate(cactusSmall, new Vector2(transform.position.x + cactusInitDistance, 1.2f), Quaternion.identity);
        }
    }

    void DeleteCactus()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        if (hit.collider != null)
            Destroy(hit.collider.gameObject);
    }
}
