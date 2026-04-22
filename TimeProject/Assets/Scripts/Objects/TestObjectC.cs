using UnityEngine;

public class TestObjectC : BaseObject
{
    public GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (objInteract)
        {
            bullet.SetActive(true);

            bullet.transform.Translate(Vector3.up * 20 *  Time.deltaTime);

            if(bullet.transform.position.y > 20)
            {
                bullet.transform.position = transform.position;
            }
        }
        if (plyInteract && !objInteract)
        {
            UIManager.Instance.dialog.DialogRequest("I only interact with the object next to me");
            plyInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ObjObjTest")
        {
            Destroy(other.gameObject);
            objInteract = true;
        }
    }
}
