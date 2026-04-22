using UnityEngine;

public class Grass : BaseObject
{
    public GameObject key;
    private bool shovelHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyInteract)
        {
            UIManager.Instance.dialog.DialogRequest("Succesfully touched grass");
            plyInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Shovel" && !shovelHit)
        {
            key.SetActive(true);
            shovelHit = true;
        }
    }
}
