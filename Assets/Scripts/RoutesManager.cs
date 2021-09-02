using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoutesManager : MonoBehaviour {

	private static RoutesManager Instance;

	[SerializeField]
	public List<Route> routes;


	private void Awake()
    {
		Instance = this;
    }


	public static List<Transform> GetRandomRoute()
    {
		return Instance.routes[Random.Range(0,Instance.routes.Count - 1)].nodes;
    }
	
	public void OnDrawGizmosSelected()
    {
		if (routes == null) return;

		foreach (Route route in routes)
        {
			for(int i = 0; i < route.nodes.Count - 1; i++)
            {
				Gizmos.DrawLine(route.nodes[i].position, route.nodes[i+1].position);
			}
		}
    }
	
	public void LoadRoutes()
    {
        routes = new List<Route>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform aux = transform.GetChild(i);

            List<Transform> nodes = new List<Transform>();

            for (int x = 0; x < aux.childCount; x ++)
            {
                nodes.Add(aux.GetChild(x));
            }
            
            Route route = new Route(nodes);

            routes.Add(route);
        }
    }
}

[CustomEditor(typeof(RoutesManager))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoutesManager routes = (RoutesManager)target;

        if (GUILayout.Button("Load Routes"))
        {
            routes.LoadRoutes();
        }
    }

}


[System.Serializable]
public class Route
{
    public Route(List<Transform> nodes)
    {
        this.nodes = nodes;
    }

	[SerializeField]
	public List<Transform> nodes;
}
