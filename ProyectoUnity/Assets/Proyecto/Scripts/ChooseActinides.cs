using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseActinides : MonoBehaviour
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
                            case "AcButton":
                                appearA(0);
                                break;
                            case "ThButton":
                                appearA(1);
                                break;
                            case "PaButton":
                                appearA(2);
                                break;
                            case "UButton":
                                appearA(3);
                                break;
                            case "NpButton":
                                appearA(4);
                                break;
                            case "PuButton":
                                appearA(5);
                                break;
                            case "AmButton":
                                appearA(6);
                                break;
                            case "CmButton":
                                appearA(7);
                                break;
                            case "BkButton":
                                appearA(8);
                                break;
                            case "CfButton":
                                appearA(9);
                                break;
                            case "EsButton":
                                appearA(10);
                                break;
                            case "FmButton":
                                appearA(11);
                                break;
                            case "MdButton":
                                appearA(12);
                                break;
                            case "NoButton":
                                appearA(13);
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
