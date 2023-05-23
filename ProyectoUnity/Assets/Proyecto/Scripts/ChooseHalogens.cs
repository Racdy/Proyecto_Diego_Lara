using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseHalogens : MonoBehaviour
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
                            case "ClButton":
                                appearA(0);
                                break;
                            case "BrButton":
                                appearA(1);
                                break;
                            case "IButton":
                                appearA(2);
                                break;
                            case "AtButton":
                                appearA(3);
                                break;
                            case "TsButton":
                                appearA(4);
                                break;
                            case "FButton":
                                appearA(5);
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
