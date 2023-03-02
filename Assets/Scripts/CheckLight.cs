using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckLight : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    }

    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    //public GameObject startingpoint;
    private Vector3 origin;


    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void LateUpdate(){

        float fov = 20f;
        int rayCount = 50;
        //origin = Vector3.zero;
        float angle = 0f;
        float angleIncrease = fov/ rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount; i++){
            Vector3 vertex;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            Debug.Log(origin);
            if (raycastHit2D.collider == null){
                //No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
                Debug.Log("No Hit");
                //Debug.Log(vertex);
            } 
            else{
                //Hit
                
                vertex = raycastHit2D.point;
                //Debug.Log(vertex);
            }

            vertices[vertexIndex] = vertex;
            if(i>0){
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;

            }
            vertexIndex++;

            angle -= angleIncrease;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }


    public void SetOrigin(Vector3 origin){
        this.origin = origin;

    }
    public void SetAimDirection(Vector3 aimDirection){

    } 
    
}
