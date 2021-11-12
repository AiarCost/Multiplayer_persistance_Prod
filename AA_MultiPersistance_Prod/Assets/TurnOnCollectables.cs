using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCollectables : MonoBehaviour
{
    public List<GameObject> CollectableList;
    // Start is called before the first frame update
    void Start()
    {
        CollectableList.AddRange(GameObject.FindGameObjectsWithTag("Collectable"));
    }

    private void OnEnable()
    {
        PlayerController.GameStartChanged += TurnOnGravity;
    }
    
    void TurnOnGravity()
    {
        PlayerController.GameStartChanged -= TurnOnGravity;
        foreach (GameObject collect in CollectableList)
        {
            collect.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
