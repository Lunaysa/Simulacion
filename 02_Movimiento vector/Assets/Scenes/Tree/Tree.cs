using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private GameObject branchPrefab;

    [SerializeField] private int recursionDepth = 2;
    [SerializeField] private int currentDepth = 0; //Nivel en el que estamos
    private Queue<GameObject>


    
    void Start()
    {
        //GenerateBranch(null);
        GenerateTree();
    }

    private void GenerateTree()
    {
        if (currentDepth >= recursionDepth) return;
        ++currentDepth;

        /*Queue<GameObject> frontier = new Queue<GameObject>();
        GameObject root = Instantiate(branchPrefab, transform);
        frontier.Enqueue(root);

        root.name = "Root Branch"; */  // Esto sirve para renombrar el nuevo oobjeto

        List<GameObject> LevelNodes = new List<GameObject>();

        while (frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            GameObject leftBranch = Instantiate(branchPrefab,transform);
            GameObject rigthBranch = Instantiate(branchPrefab, transform);

        }

        foreach (GameObject node in levelNodes)
        {
            frontier.Enqueue(node);
        }
    }
    
   

    private GameObject GenerateBranch(GameObject prevBranch)
    { 
        //Generate the new branch
        GameObject branch = Instantiate(branchPrefab, transform);
        if (prevBranch != null)
        {
            branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
            Quaternion prevRotation = prevBranch.transform.rotation;

            prevRotation = Quaternion.Euler(0f, 0f, 45f);
            branch.transform.rotation = prevRotation;
        }

        //Generar arbol
        GenerateBranch(branch);
        
    }
}
