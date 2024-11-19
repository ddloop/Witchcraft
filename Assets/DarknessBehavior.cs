using UnityEngine;

public class DarknessBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 0.01f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("MagicTile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
