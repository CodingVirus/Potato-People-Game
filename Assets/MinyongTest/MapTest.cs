using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTest : MonoBehaviour
{
    public GameObject cmr;
    private CameraFollow test;
    mapPostion cameratest, f3 , f2;

    class mapPostion
    {
        float minX, maxX, minY, maxY;
        int count;
        bool result;
        public float[] arr = new float[4];

        public mapPostion(float a, float b, float c, float d)
        {
            this.minX = a;
            this.maxX = b;
            this.minY = c;
            this.maxY = d;

            this.arr[0] = minX;
            this.arr[1] = maxX;
            this.arr[2] = minY;
            this.arr[3] = maxY;
        }

        public bool comparePosition(float[] cmp)
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.arr[i] == cmp[i])
                {
                    count++;
                }
            }

            Debug.Log(count);

            if (count >= 4)
            {
                count = 0;
                return true;
            }

            else
            {
                count = 0;
                return false;
            }
            
        }
    }

    private void Start()
    {
        test = cmr.GetComponent<CameraFollow>();
        cameratest = new mapPostion(test.limitMinX, test.limitMaxX, test.limitMinY, test.limitMaxY);
        f3 = new mapPostion(-45f, 11f, -72f, -61f);
        f2 = new mapPostion(-45f, 30f, -46f, -35f);
    }
    private void Update()
    {
        Debug.Log(cameratest.comparePosition(f3.arr));
        if (test.limitMinX == -45f && test.limitMaxX == 11f && test.limitMinY == -72f && test.limitMaxY == -61f)
        {
            this.transform.localPosition = new Vector3(0, 320, 0);
        }

        if (cameratest.comparePosition(f3.arr) == true)
        {
            
        }
    }
}
