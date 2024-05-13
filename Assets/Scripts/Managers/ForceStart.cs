using UnityEngine;

using UnityEngine.SceneManagement;



public class ForceStart : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("VillageScecne") != 0)
        {
            SceneManager.LoadScene("VillageScecne");
        }
    }
}