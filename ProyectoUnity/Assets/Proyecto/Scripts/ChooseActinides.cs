using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Vuforia;

public class ChooseActinides : MonoBehaviour
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
