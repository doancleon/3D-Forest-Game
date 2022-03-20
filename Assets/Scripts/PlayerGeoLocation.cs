using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGeoLocation : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject edgeWorld;
    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject volcano;
    [SerializeField] private GameObject appleTree;
    [SerializeField] private GameObject trees;
    [SerializeField] private GameObject apple1;
    [SerializeField] private GameObject apple2;
    [SerializeField] private GameObject apple3;
    private int appleCount = 0;

    private Animator fish_animator;
    private Animator volcano_animator;
    private Animator tree_animator;

    private GameObject ex_log;
    private GameObject bad_log;
    private GameObject good_log;
    private GameObject hint_log;
    private GameObject stray_log;
    [SerializeField] private Text pecularities;

    private bool nearFire = false;
    private bool foundFire = false;
    private bool nearEdgeWorld = false;
    private bool foundEdgeWorld = false;
    private bool nearFish = false;
    private bool foundFish = false;
    private bool nearVolcano = false;
    private bool foundVolcano = false;
    private bool nearAppleTree = false;
    private bool foundAppleTree = false;
    private bool nearTrees = false;
    private bool foundTrees = false;
    // Update is called once per frame
    void Start()
    {
        ex_log = transform.Find("canvas_log").gameObject;
        bad_log = transform.Find("bad_log_canvas").gameObject;
        good_log = transform.Find("good_log_canvas").gameObject;
        hint_log = transform.Find("hint_log_canvas").gameObject;
        stray_log = transform.Find("stray_log_canvas").gameObject;

    fish_animator = fish.GetComponent<Animator>();

        volcano_animator = volcano.GetComponent<Animator>();
        tree_animator = appleTree.GetComponent<Animator>();
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
        if (Vector3.Distance(fish.transform.position, transform.position) < 3)
        {
            nearFish = true;
        }
        else
        {
            nearFish = false;
        }
        if (Vector3.Distance(volcano.transform.position, transform.position) < 6 && !(bad_log.activeInHierarchy) && !(good_log.activeInHierarchy) && !(hint_log.activeInHierarchy) && !(foundVolcano) &&!(stray_log.activeInHierarchy))
        {
            hint_log.SetActive(true);
            StartCoroutine("loggingTimer");
        }
        if (Vector3.Distance(volcano.transform.position, transform.position) < 3)
        {
            nearVolcano = true;
        }
        else
        {
            nearVolcano = false;
        }
        if (Vector3.Distance(trees.transform.position, transform.position) < 2)
        {
            nearTrees = true;
        }
        else
        {
            nearTrees = false;
        }
        if (Vector3.Distance(appleTree.transform.position, transform.position) < 2)
        {
            nearAppleTree = true;
        }
        else
        {
            nearAppleTree = false;
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
        else if (!nearFire)
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

        if (nearTrees)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (!foundTrees)
                    pecularities.text += "\n     -Tree-huggers: There are trees on this planet!";
                foundTrees = true;
            }
        }
        if (nearAppleTree)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                tree_animator.SetBool("wiggle", true);
                StartCoroutine("waitTree");
                if (!foundAppleTree)
                    pecularities.text += "\n     -The Big Apple: There are huge apple trees that grow gigantic and delicious apples!";
                foundAppleTree = true;
                if (appleCount == 0) {
                    tree_animator.SetBool("wiggle", true);
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
                    apple1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                }
                else if (appleCount == 1)
                {
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
                    apple2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                }
                if (appleCount == 2)
                {
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
                    apple3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
                }

                appleCount += 1;

            }
        }

        if (nearFish)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                fish_animator.SetBool("swimming", true);
                if (!foundFish)
                    pecularities.text += "\n     -Fish out of water!: There's no sign of water... but it looks like fish don't need it.";
                foundFish = true;
            }
        }
        else if (!nearFish)
        {
            fish_animator.SetBool("swimming", false);
        }

        if (nearVolcano)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                volcano.transform.Find("fireEffects").gameObject.SetActive(true);
                volcano_animator.SetBool("erupting", true);
                if (!foundVolcano)
                    pecularities.text += "\n     -Mini-Volcanos erupting!";
                foundVolcano = true;
            }
        }
        else if (!nearVolcano)
        {
            volcano.transform.Find("fireEffects").gameObject.SetActive(false);
            volcano_animator.SetBool("erupting", false);
        }

        if (Input.GetKeyDown(KeyCode.X) && !(nearFire || nearEdgeWorld || nearFish || nearVolcano||nearTrees||nearAppleTree) && !(bad_log.activeInHierarchy))
        {
            stray_log.SetActive(false);
            hint_log.SetActive(false);
            good_log.SetActive(false);
            bad_log.SetActive(true);
            StartCoroutine("loggingTimer");
        }
        else if (Input.GetKeyDown(KeyCode.X) && !(good_log.activeInHierarchy) && (nearFire || nearEdgeWorld || nearFish || nearVolcano ||nearTrees||nearAppleTree))
        {
            stray_log.SetActive(false);
            hint_log.SetActive(false);
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
        hint_log.SetActive(false);
        stray_log.SetActive(false);
    }
    private IEnumerator waitTree()
    {
        yield return new WaitForSeconds(2.0f);
        tree_animator.SetBool("wiggle", false);


    }



    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "stray")
        {
            bad_log.SetActive(false);
            good_log.SetActive(false);
            hint_log.SetActive(false);
            stray_log.SetActive(true);
            StartCoroutine("loggingTimer");
        }
    }
}