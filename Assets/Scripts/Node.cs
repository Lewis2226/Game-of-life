using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    float num;
    int ID;
    List<Edge> Edges;

    public Node(float num, int _ID, List<Edge> _Edges)
    {
        this.num = num;
        this.ID = _ID;
        this.Edges = _Edges;
    }

    public float Getnum()
    {
        return num;
    }

    public void Setnum(float _num)
    {
        num = _num;
    }

    public int Getid()
    {
        return ID;
    }

    public void Setid(int _ID)
    {
        ID = _ID;
    }

    public  List<Edge> GetEdges()
    {
        return Edges;
    }

    public void SetEdges(List<Edge> edges)
    {
        Edges = edges;
    }


}
