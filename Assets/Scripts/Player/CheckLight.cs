using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckLight : MonoBehaviour
{
    public static Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    }
    public static float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;

        return n;
    }
    //Public variables so we can test in runtime
    [SerializeField] private LayerMask layerMask;
    private Mesh        mesh;
    public Vector3      origin;
    public Transform    torchposition;
    public float        startingAngle;
    public float        fov = 20f;
    public float        viewDistance = 50f;
    public FollowAim    playerAim;
    
    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
    }
    private void LateUpdate(){
        

        int rayCount = 50;
        origin = torchposition.position;
        //float angle = startingAngle;
        //Debug.Log(torchposition.localEulerAngles.z);

        float angle = playerAim.rotationZ + 10;

        float angleIncrease = fov/ rayCount;
        mesh.RecalculateBounds();
        
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= rayCount; i++){
            Vector3 vertex;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null){
                //No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
                //Debug.Log("No Hit");
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
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov /2f;
    } 
    
}