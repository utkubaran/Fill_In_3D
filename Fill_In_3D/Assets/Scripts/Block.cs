using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isPlaced = false;

    private void OnTriggerEnter(Collider other)
    {
        BaseBlock baseBlock = other.GetComponent<BaseBlock>();

        if(baseBlock && !isPlaced)
        {
            isPlaced = true;

            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            other.gameObject.SetActive(false);

            GetComponent<MeshRenderer>().material.color = baseBlock.color;

            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;

            GameManager.instance.IncreaseBlockPlaced();
        }
    }
}
