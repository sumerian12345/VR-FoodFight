using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public BoxCollider area;

    public GameManager gameM;


    // Start is called before the first frame update
    void Start()
    {
        // gameM.NonStaticInstance
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var foodStuff = collision.gameObject.GetComponent<XRGrabInteractable>();

        if(foodStuff != null && GameManager)
        {
            Destroy(collision.gameObject);
            ChangeRandomPosition();

            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnFoodItem();
        }
    }

    private void ChangeRandomPosition()
    {
        float x = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float y = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float z = Random.Range(area.bounds.min.x, area.bounds.max.x);

        transform.position = new Vector3(x, y, z);
    }
}
