using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseTransitionMetals : MonoBehaviour
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
                            case "ScButton":
                                appearA(0);
                                break;
                            case "TiButton":
                                appearA(1);
                                break;
                            case "VButton":
                                appearA(2);
                                break;
                            case "CrButton":
                                appearA(3);
                                break;
                            case "MnButton":
                                appearA(4);
                                break;
                            case "FeButton":
                                appearA(5);
                                break;
                            case "CoButton":
                                appearA(6);
                                break;
                            case "NiButton":
                                appearA(7);
                                break;
                            case "CuButton":
                                appearA(8);
                                break;
                            case "ZnButton":
                                appearA(9);
                                break;
                            case "YButton":
                                appearA(10);
                                break;
                            case "ZrButton":
                                appearA(11);
                                break;
                            case "NbButton":
                                appearA(12);
                                break;
                            case "MoButton":
                                appearA(13);
                                break;
                            case "TcButton":
                                appearA(14);
                                break;
                            case "RuButton":
                                appearA(15);
                                break;
                            case "RhButton":
                                appearA(16);
                                break;
                            case "PdButton":
                                appearA(17);
                                break;
                            case "AgButton":
                                appearA(18);
                                break;
                            case "CdButton":
                                appearA(19);
                                break;
                            case "LuButton":
                                appearA(20);
                                break;
                            case "HfButton":
                                appearA(21);
                                break;
                            case "TaButton":
                                appearA(22);
                                break;
                            case "WButton":
                                appearA(23);
                                break;
                            case "ReButton":
                                appearA(24);
                                break;
                            case "OsButton":
                                appearA(25);
                                break;
                            case "IrButton":
                                appearA(26);
                                break;
                            case "PtButton":
                                appearA(27);
                                break;
                            case "AuButton":
                                appearA(28);
                                break;
                            case "HgButton":
                                appearA(29);
                                break;
                            case "LrButton":
                                appearA(30);
                                break;
                            case "RfButton":
                                appearA(31);
                                break;
                            case "DbButton":
                                appearA(32);
                                break;
                            case "SgButton":
                                appearA(33);
                                break;
                            case "BhButton":
                                appearA(34);
                                break;
                            case "HsButton":
                                appearA(35);
                                break;
                            case "MtButton":
                                appearA(36);
                                break;
                            case "DsButton":
                                appearA(37);
                                break;
                            case "RgButton":
                                appearA(38);
                                break;
                            case "CnButton":
                                appearA(39);
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
