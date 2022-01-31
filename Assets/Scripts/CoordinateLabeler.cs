using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;//for Text Mesh Pro


//this script will be executed both in edit mode and play mode
[ExecuteAlways]

public class CoordinateLabeler : MonoBehaviour
{
    [Tooltip("This is used to access the text component of each tile.")] TextMeshPro label;
    [Tooltip("Determines coordinates of each tile.")] Vector2Int coordinates = new Vector2Int();


    void Awake()
    {
        //referencing to object via code
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        //UpdateGameobjectName();
    }


    void Update()
    {
        //this part is executed in edit mode
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateGameobjectName();
        }

    }

    void DisplayCoordinates()
    {
        //coordinates of a textmesh component is that of its parent
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);//the last devision is to start from 0,0
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);//we are working in 2D of x, z

        label.text = coordinates.x.ToString() + "," + coordinates.y.ToString();
    }

    void UpdateGameobjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
