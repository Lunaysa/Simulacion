using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private GameObject branchPrefab;

    [SerializeField] private int recursiveDepth;

    [Header("Other")]
    [SerializeField]
    private float rootLength;

    private float currentLengt = -1;

    [SerializeField]
    private float reductionLengthPerLevel = 0.1f;

    private int currentDepth = 0; //Nivel en el que estamos
    private Queue<GameObject> frontier = new Queue<GameObject>();


    
    void Start()
    {
        currentLengt = rootLength;
        GameObject root = Instantiate(branchPrefab, transform);
        SetBranchLength(root, currentLengt);

        frontier.Enqueue(root);
        //++currentDepth;
        //GenerateBranch(null);
        GenerateTree();
    }
    private void GenerateTree()
    {
        if (currentDepth >= recursiveDepth) return;
        ++currentDepth;

        /*Queue<GameObject> frontier = new Queue<GameObject>();
        GameObject root = Instantiate(branchPrefab, transform);
        frontier.Enqueue(root);

        root.name = "Root Branch"; */  // Esto sirve para renombrar el nuevo oobjeto

        //Reduce la longitud de cada nivel
        rootLength -= rootLength * reductionLengthPerLevel;


        List<GameObject> levelNodes = new List<GameObject>();

        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            GameObject leftBranch = GenerateBranch(branch, Random.Range(10f, 30f));
            GameObject rigthBranch = GenerateBranch(branch, -Random.Range(10f, 30f));

            levelNodes.Add(leftBranch);
            levelNodes.Add(rigthBranch);

        }



        foreach (GameObject node in levelNodes)
        {
            frontier.Enqueue(node);

        }

        GenerateTree();
    }
    
    private GameObject GenerateBranch(GameObject prevBranch, float angle)
    { 
        //Generate the new branch
        GameObject branch = Instantiate(branchPrefab, transform);
        

        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up * currentLengt;
        Quaternion prevRotation = prevBranch.transform.rotation;
        SetBranchLength(branch, currentLengt);

        prevRotation *= Quaternion.Euler(0f, 0f, angle);
        branch.transform.rotation = prevRotation;

        return branch;

    }

    //Aca se escala
    private void SetBranchLength(GameObject branch, float length)
    {
        Transform line = branch.transform.GetChild(1);
        Transform circle = branch.transform.GetChild(0);

        line.localScale = new Vector3(line.localScale.x, length, line.localScale.z);
        line.localPosition = new Vector3(0f, length * 0.5f, 0f);
        circle.localPosition = new Vector3(0f, length * 0.5f, 0f);
    }
}
