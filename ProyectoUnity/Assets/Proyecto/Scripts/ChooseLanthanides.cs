using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseLanthanides : MonoBehaviour
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
                            case "LaButton":
                                appearA(0);
                                break;
                            case "CeButton":
                                appearA(1);
                                break;
                            case "PrButton":
                                appearA(2);
                                break;
                            case "NdButton":
                                appearA(3);
                                break;
                            case "PmButton":
                                appearA(4);
                                break;
                            case "SmButton":
                                appearA(5);
                                break;
                            case "EuButton":
                                appearA(6);
                                break;
                            case "GdButton":
                                appearA(7);
                                break;
                            case "TbButton":
                                appearA(8);
                                break;
                            case "DyButton":
                                appearA(9);
                                break;
                            case "HoButton":
                                appearA(10);
                                break;
                            case "ErButton":
                                appearA(11);
                                break;
                            case "TmButton":
                                appearA(12);
                                break;
                            case "YbButton":
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
