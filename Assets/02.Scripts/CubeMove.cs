using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

    public readonly string BGBOX = "BGBox";
    public readonly string STAYBOX = "StayBox";
    public readonly string MOVEBOX = "MoveBox";

    public GameObject newBox;
    public GameObject bgBox;
    

    private void Start()
    {
        newBox = (GameObject)Resources.Load("StayBox");
        bgBox = GameObject.Find("BGBox");
    } 

    private void Update()
    {
        #region Move
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            transform.Translate(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            transform.Translate(0, 0, 1);
        }
        #endregion /Move
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(STAYBOX)) {
            this.GetComponent<Renderer>().material.color = new Color32(255, 0, 80, 100);
            if (Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("STAYBOX");
                Destroy(other.gameObject);
            }
        }
        if (other.CompareTag(BGBOX)&&!other.CompareTag(STAYBOX)) {
                this.GetComponent<Renderer>().material.color = new Color32(0,160,255,100);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("BGBOX");
                Instantiate(newBox, transform.position, Quaternion.identity, bgBox.transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
            Debug.Log("NULL");
            this.GetComponent<Renderer>().material.color = new Color32(255, 0, 80, 100);
    }


}
