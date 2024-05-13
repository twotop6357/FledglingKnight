using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkWithPillar : MonoBehaviour
{
    public GameObject player;
    public float actionDistance = 1f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player == null)
            {
                return;
            }
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= actionDistance)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}