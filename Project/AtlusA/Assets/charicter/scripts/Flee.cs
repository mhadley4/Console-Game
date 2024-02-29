using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flee : MonoBehaviour
{

    [SerializeField] private string SampleScene = "SampleScene";

    // Start is called before the first frame update
    public void Fleeing()
    {
        SceneManager.LoadScene(SampleScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
