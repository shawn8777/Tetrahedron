/*
作者名称:YHB

脚本作用:脚本绘制四面体

建立时间:2016.8.1.14.33
*/

using UnityEngine;
using System.Collections;

public class Tetrahedron : MonoBehaviour
{
    #region 4个顶点
    //0,0,0
    //1,0,0
    //0.5,0,sqrt(0.75)
    //0.5,sqrt(0.75),sqrt(0.75)/3
    #endregion

    void Start()
    {
        Create();
    }

    //创建的方法
    public void Create()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();//固定
        if (meshFilter == null)
        {
            Debug.LogError("没有MeshFilter组件，请添加!!!");
            return;
        }

        //顶点
        Vector3 p0 = new Vector3(0, 0, 0);
        Vector3 p1 = new Vector3(1, 0, 0);
        Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
        //Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);
        Vector3 p3 = new Vector3(0, 1, 0);
        Vector3 p4 = new Vector3(1, 1, 0);
        Vector3 p5 = new Vector3(0.5f, 1, Mathf.Sqrt(0.75f));

        //创建网格
        Mesh mesh = meshFilter.sharedMesh;//固定
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();//固定

        //有哪些顶点
        mesh.vertices = new Vector3[] { p0, p1, p2, p3, p4, p5 };
        //顶点组织成三角面
        /*mesh.triangles = new int[] {
            0,1,2,
            0,2,3,
            2,1,3,
            0,3,1
        };*/
        mesh.triangles = new int[] {
            0,1,2,
            0,4,1,
            0,3,4,//---
            2,3,0,
            2,5,3,//---
            1,4,5,
            1,5,2,
            3,5,4
        };


        mesh.RecalculateNormals();//固定
        mesh.RecalculateBounds();//固定
        mesh.Optimize();//固定
    }
}
