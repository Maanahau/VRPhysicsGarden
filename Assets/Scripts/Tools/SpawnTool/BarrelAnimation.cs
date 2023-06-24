using UnityEngine;

public class BarrelAnimation : MonoBehaviour
{
    [SerializeField] GameObject barrel;

    private void Update()
    {
        barrel.transform.Rotate(Vector3.right, 200f * Time.deltaTime);
    }
}
