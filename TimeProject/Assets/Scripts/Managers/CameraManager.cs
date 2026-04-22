using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //The camera is a singleton
    public static CameraManager instance;

    private Camera cam;

    public bool getRequest;
    public bool completeRequest;

    public int requestType;
    //0 none| 1 zoom out level | 2 zoom into player | 3 go to default

    [SerializeField]
    float zoomOutFov, zoomPlyFov, defaultFov, zoomOutXRot, zoomPlyXrot, defaultXrot;
    [SerializeField]
    Vector3 zoomOutPos, zoomPlyPos, defaultPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        getRequest = false;
        completeRequest = true;
        cam = GetComponent<Camera>();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (getRequest)
        {
            switch (requestType)
            {
                case 1:

                    if(cam.fieldOfView < zoomOutFov)
                    {
                        cam.fieldOfView++;
                    }
                    else
                    {
                        cam.fieldOfView = zoomOutFov;
                        getRequest = false;
                        completeRequest = true;
                        requestType = 0;
                    }

                    break;

                case 2:

                    zoomPlyPos = new Vector3(Mathf.Ceil(PlayerScript.instance.gameObject.transform.position.x), Mathf.Ceil(PlayerScript.instance.gameObject.transform.position.y) + 1, zoomPlyPos.z);
                    completeRequest = true;

                    if (cam.fieldOfView > zoomPlyFov)
                    {
                        cam.fieldOfView--;
                        completeRequest = false;
                    }
                    else
                    {
                        cam.fieldOfView = zoomPlyFov;
                    }

                    if (transform.rotation.eulerAngles.x > zoomPlyXrot && transform.rotation.eulerAngles.x <= defaultXrot)
                    {
                        transform.Rotate(-0.5f,0,0);
                        completeRequest = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(zoomPlyXrot, 0, 0);
                    }


                    if (transform.position != zoomPlyPos)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, zoomPlyPos, 0.5f);
                        completeRequest = false;
                    }
                    else
                    {
                        transform.position = zoomPlyPos;
                    }

                    if (completeRequest)
                    {
                        getRequest = false;
                        requestType = 0;
                    }

                    break;

                case 3:

                    completeRequest = true;

                    if (cam.fieldOfView > defaultFov)
                    {
                        cam.fieldOfView--;
                        completeRequest = false;
                    }
                    else if(cam.fieldOfView < defaultFov)
                    {
                        cam.fieldOfView++;
                        completeRequest = false;
                    }
                    else
                    {
                        cam.fieldOfView = defaultFov;
                    }

                    if (transform.rotation.eulerAngles.x < defaultXrot)
                    {
                        transform.Rotate(0.5f, 0, 0);
                        completeRequest = false;
                    }


                    if (transform.position != defaultPos)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, defaultPos, 0.5f);
                        completeRequest = false;
                    }
                    else
                    {
                        transform.position = defaultPos;
                    }

                    if (completeRequest)
                    {
                        getRequest = false;
                        requestType = 0;
                    }

                    break;
            }
        }
    }
}
