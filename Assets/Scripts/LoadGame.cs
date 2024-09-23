using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Awake() => SceneManager.LoadScene(1);
}
