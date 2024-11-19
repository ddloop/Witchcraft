using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject witchPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (witchPlayer.transform.position.y < -10)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name ,LoadSceneMode.Single);
    }
}
