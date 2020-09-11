using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    public float xRot = 5;
    public float yRot = 5;
    public float minY = -20;
    public float maxY = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X") * xRot;
        float v = Input.GetAxis("Mouse Y") * yRot;

        Vector3 rotation = new Vector3(-v, h, 0);
        transform.Rotate(rotation * Time.deltaTime);

        Vector3 tempRotation = transform.localEulerAngles;
        tempRotation.z = 0;
        if (tempRotation.x > 200) {
            tempRotation.x =  tempRotation.x - 360;
        }
        tempRotation.x = Mathf.Clamp(tempRotation.x, minY, maxY);
        transform.localEulerAngles = tempRotation;
    }
}
