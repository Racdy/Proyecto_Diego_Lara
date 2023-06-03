using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseTransitionMetals : MonoBehaviour
{
    private Camera cameraAR; //Camera from Vuforia
    public GameObject[] atoms;  //Array for atoms
    string button;              //tags for buttons
    public Vector3 scaleInitial = new Vector3(0.5f, 0.5f, 0.5f); // Initial scale -> Smaller
    public Vector3 scaleFinal = new Vector3(20f, 20f, 20f); // Final scale -> Bigger
    public float duration = 2f; // Duration time for animation
    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f); //Rotatio speed for rotate atoms

    // Start is called before the first frame update
    void Start()
    {
        cameraAR = VuforiaBehaviour.Instance.GetComponent<Camera>(); //Asing camera from Vuforia

        for (int i = 0; i < atoms.Length; i++)              //Loop for disable and give initial scale to atoms
        {
            atoms[i].SetActive(false);
            atoms[i].transform.localScale = scaleInitial;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (GameObject atom in atoms)  //Loop for atoms
        {
            atom.transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0)    //Condition for get touch from screen 
        {

            foreach (Touch touch in Input.touches)  //Looping through all current touches
            {
                if (touch.phase == TouchPhase.Began) //Condition when touch press is detected
                {
                    Ray ray = cameraAR.ScreenPointToRay(Input.GetTouch(0).position); //Set a ray from camera and touch screen
                    RaycastHit hit;                                                  //Gets hit button
                    if (Physics.Raycast(ray, out hit))                               //Condition if ray hits a button do the next code
                    {
                        button = hit.transform.name;                                //Get button name
                        switch (button)                                             //Switch for all buttons name, calls method for appers or desapper the atom
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

    public void appearA(int nButton)        //Method for apperd or desapper atoms
    {
        if (atoms[nButton].activeSelf)      //Disable atom is this active (On screen) and set it his initial scale
        {
            atoms[nButton].SetActive(false);
            atoms[nButton].transform.localScale = scaleInitial;
        }
        else  //Else, disable any active button and enable the atom called from button. And call StartCoroutine for scale animation
        {
            for (int i = 0; i < atoms.Length; i++)
            {
                atoms[i].SetActive(false);
                atoms[i].transform.localScale = scaleInitial;
            }
            atoms[nButton].SetActive(true);
            StartCoroutine(ScaleObject(atoms[nButton], scaleInitial, scaleFinal, duration));

        }
    }

    IEnumerator ScaleObject(GameObject obj, Vector3 startScale, Vector3 endScale, float duration)   //Method for animation apper
    {                                                                                               //With a difference of time make Linear interpolation between scales            
        float timePassed = 0f;

        while (timePassed < duration)
        {
            float t = timePassed / duration;
            obj.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            timePassed += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = endScale;
    }
}