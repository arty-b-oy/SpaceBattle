using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] private Transform wallLeft;
    [SerializeField] private Transform wallRigth;
    [SerializeField] private Transform wallUp;
    [SerializeField] private Transform wallDown;
    private const float  positionYwall = 10.5f;
    void Start()
    {
        float AspectRatio = (float)Screen.width / (float)Screen.height;
        wallLeft.transform.position = new Vector3(- positionYwall * AspectRatio,
                                                  wallLeft.transform.position.y,
                                                  wallLeft.transform.position.z);
        wallRigth.transform.position = new Vector3(positionYwall * AspectRatio,
                                                   wallRigth.transform.position.y,
                                                   wallRigth.transform.position.z);
    }
}
