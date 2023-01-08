using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform objTransform;

    [SerializeField] private Vector3 offset = new Vector3(0,0,-10f);

    [SerializeField] private float camSpeed = 5f;

    private void Update()
    {
        if (objTransform != null)
        {
        Vector3 newCamPos = new Vector3(objTransform.position.x, objTransform.position.y, offset.z);

        transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);

        }

    }

}
