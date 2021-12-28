using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private float rotationDuration = 3f;
    private bool rotating;



    
    public void Rotate(bool right)
    {

        if (!rotating)
        {
            StartCoroutine(RotateEnum(right));
        }

    }

    [ContextMenu("Do Something")]
    public void RotateRight()
    {

        Rotate(true);

    }
    IEnumerator RotateEnum(bool right)
    {
        Debug.Log("test");
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        int direction = right ? 1 : -1;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 120 * direction, 0);

        while (timeElapsed < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotationDuration);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rotating = false;
    }

}
