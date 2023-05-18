using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseNonMetals : MonoBehaviour
{
    private Camera cameraAR;
    private bool apperModel = true;
    public GameObject[] atoms;
    private int nButton;
    string button;
    // Start is called before the first frame update
    void Start()
    {
        cameraAR = VuforiaBehaviour.Instance.GetComponent<Camera>();
        for (int i = 0; i < atoms.Length; i++)
        {
            atoms[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = cameraAR.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        button = hit.transform.name;
                        switch (button) {
                            case "HButton":
                                appearA(0);
                                break;
                            case "CButton":
                                appearA(1);
                                break;
                            case "NButton":
                                appearA(2);
                                break;
                            case "OButton":
                                appearA(3);
                                break;
                            case "PButton":
                                appearA(4);
                                break;
                            case "SButton":
                                appearA(5);
                                break;
                            case "SeButton":
                                appearA(6);
                                break;
                            default:
                                break;
                            
                        }
                       
                    }
                }
            }
        }
    }

    public void appearA(int nBotton)
    {

        if (atoms[nButton].activeSelf)
        {
            atoms[nButton].SetActive(false);
        }
        else {
            atoms[nButton].SetActive(true); 
        }

    }
}