using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGeoLocation : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject edgeWorld;
    private GameObject ex_log;
    private GameObject bad_log;
    private GameObject good_log;
    [SerializeField] private Text pecularities;

    private bool nearFire = false;
    private bool foundFire = false;
    private bool nearEdgeWorld = false;
    private bool foundEdgeWorld = false;
    // Update is called once per frame
    void Start()
    {
        ex_log = transform.Find("canvas_log").gameObject;
        bad_log = transform.Find("bad_log_canvas").gameObject;
        good_log = transform.Find("good_log_canvas").gameObject;
    }
    void Update()
    {
        //explorers log
        if (Input.GetKeyDown(KeyCode.M))
        {
            ex_log.SetActive(!ex_log.activeInHierarchy);
        }


        //check if near distance of peculiarity
        if (Vector3.Distance(fire.transform.position, transform.position) < 1)
        {
            nearFire = true;
        }
        else
        {
            nearFire = false;
        }
        if (Vector3.Distance(edgeWorld.transform.position, transform.position) < 1)
        {
            nearEdgeWorld = true;
        }
        else
        {
            nearEdgeWorld = false;
        }


        //check if logging
        if (nearFire)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                fire.transform.Find("fireEffects").gameObject.SetActive(true);
                if (!foundFire)
                    pecularities.text += "\n     -There's fire on this planet!";
                            foundFire = true;
            }
            fire.transform.Find("fireText").gameObject.SetActive(true);
            if (fire.transform.Find("fireEffects").gameObject.activeSelf)
            { 
                fire.transform.Find("fireText").gameObject.SetActive(false);
            }
        }
        else
        {
            fire.transform.Find("fireEffects").gameObject.SetActive(false);
            fire.transform.Find("fireText").gameObject.SetActive(false);
        }

        if (nearEdgeWorld)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (!foundEdgeWorld)
                    pecularities.text += "\n     -Flatworlders: The Edge of the World?";
                foundEdgeWorld = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && !(nearFire || nearEdgeWorld) && !(bad_log.activeInHierarchy))
        {
            good_log.SetActive(false);
            bad_log.SetActive(true);
            StartCoroutine("loggingTimer");
        }
        else if (Input.GetKeyDown(KeyCode.X) && !(good_log.activeInHierarchy) && (nearFire||nearEdgeWorld))
        {
            bad_log.SetActive(false);
            good_log.SetActive(true);
            StartCoroutine("loggingTimer");
        }
    }
    private IEnumerator loggingTimer()
    {
        yield return new WaitForSeconds(2.0f);
        bad_log.SetActive(false);
        good_log.SetActive(false);
    }
}
