using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colect : MonoBehaviour
{
    public float collected;
    float updateMoney;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "col")
        {
            collected = collected + 10.0f;
            updateMoney = PlayerPrefs.GetFloat("money");
            PlayerPrefs.SetFloat("money", updateMoney + 10.0f);
            //result = nn.fs.File.Write(fileHandle, offset, data, data.LongLength, nn.fs.WriteOption.Flush);
            print (collected);
            Destroy (coll.gameObject);
        }
    }

    private void Update()
    {
#if UNITY_SWITCH
        if (Input.GetButtonDown("SaveTemp"))
        {
            Debug.Log("hello");
        }
#endif
    }
}
