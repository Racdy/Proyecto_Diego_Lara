using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseOtherMetals : MonoBehaviour
{
    private Camera cameraAR;
    public GameObject[] atoms;
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
                        switch (button)
                        {
                            case "AlButton":
                                appearA(0);
                                break;
                            case "GaButton":
                                appearA(1);
                                break;
                            case "InButton":
                                appearA(2);
                                break;
                            case "TlButton":
                                appearA(3);
                                break;
                            case "NhButton":
                                appearA(4);
                                break;
                            case "SnButton":
                                appearA(5);
                                break;
                            case "PbButton":
                                appearA(6);
                                break;
                            case "BiButton":
                                appearA(7);
                                break;
                            case "McButton":
                                appearA(8);
                                break;
                            case "FlButton":
                                appearA(9);
                                break;
                            case "LvButton":
                                appearA(10);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }

    public void appearA(int nButton)
    {

        if (atoms[nButton].activeSelf)
        {
            atoms[nButton].SetActive(false);
        }
        else
        {
            atoms[nButton].SetActive(true);
        }

    }
}
