using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSpline : MonoBehaviour
{
    public Transform[] points;
    public int detailPoints = 5;
    [Range(0,1)] public float globalLerp;

    Vector3[] mid;
    Vector3[] mid2;

    public List<Vector3> segments = new List<Vector3>();

    private void Awake() {
        points = GetComponentsInChildren<Transform>();
    }

    private void OnDrawGizmos() {

        mid = new Vector3[points.Length-1];
        mid2 = new Vector3[mid.Length-1];

        for(int i=0; i< points.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(points[i].position, 0.1f);

            Gizmos.color = Color.white;
            if(i!=0) Gizmos.DrawLine(points[i].position, points[i-1].position);
        }

        DrawRealtimeGizmo();

        Vector3 from = points[0].position;

        segments.Clear();

        for(int i=0; i<detailPoints; i++){
            float t = (i+1)/(float)detailPoints;
            
            var to = DrawSegment(t);

            segments.Add(to);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(from, to);
            // Debug.Log($"<color=green>{t} = {from} {to}</color>");

            from = to;
        }
    }

    private void DrawRealtimeGizmo() {
        for(int i=0; i< points.Length-1; i++)
        {
            // Gizmos.color = Color.cyan;

            mid[i] = Vector3.Lerp(points[i].position, points[i+1].position, globalLerp);
            // Gizmos.DrawSphere(mid[i], 0.05f);
        }

        // for(int i =1; i< mid.Length; i++){
        //     Gizmos.color = Color.gray;
        //     Gizmos.DrawLine(mid[i], mid[i-1]);
        // }

        for(int i=0; i< mid.Length-1; i++){
            Gizmos.color = Color.yellow;

            mid2[i] = Vector3.Lerp(mid[i], mid[i+1], globalLerp);
            Gizmos.DrawSphere(mid2[i], 0.05f);
        }

        // mid2 line
        for(int i =1; i< mid2.Length; i++){
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(mid2[i], mid2[i-1]);
        }

        for(int i=0; i< mid2.Length-1; i++){
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(Vector3.Lerp(mid2[i], mid2[i+1], globalLerp), 0.05f);
        }
    }

    private Vector3 DrawSegment(float t){
        for(int i=0; i<points.Length-1; i++)
        {
            mid[i] = Vector3.Lerp(points[i].position, points[i+1].position, t);
        }

        for(int i=0; i< mid.Length-1; i++){
            mid2[i] = Vector3.Lerp(mid[i], mid[i+1], t);
        }
        
        return Vector3.Lerp(mid2[0], mid2[1], t);
    }

}
