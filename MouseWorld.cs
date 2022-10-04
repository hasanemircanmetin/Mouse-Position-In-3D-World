using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld Instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;

    private Camera _cam;

    private void Awake()
    {
        SingletonCheck();
        _cam = Camera.main;
    }

    public static Vector3 GetPosition3D()
    {
        Ray ray = Instance._cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, Instance.mousePlaneLayerMask);
        return hit.point;
    }

    public static Vector3 GetPosition2D()
    {
        Vector3 worldPosition = Instance._cam.ScreenToWorldPoint(Input.mousePosition);
        return worldPosition;
    }

    private void SingletonCheck()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}