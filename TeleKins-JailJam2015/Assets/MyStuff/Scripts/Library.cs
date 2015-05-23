using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CrackSw;
/// <summary>
/// NAME: Library.cs
/// AUTHOR: Asger Gitz-Johansen
/// 
/// DESCRIPTION: This script is used to store various 
/// functions and can be used is many situations.
/// 
/// Most of these functions are quite simple, and can
/// be used by anyone, who would like to.
/// 
/// </summary>
namespace CrackSw
{
    public class Data
    {
        public static void Save(string filePath, string saveData, int lineIndex)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        sw.WriteLine("N/A");
                    }
                }
                Save(filePath, saveData, lineIndex);
                return;
            }
            else
            {
                string[] oldLines = File.ReadAllLines(filePath);
                
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    for (int currentLine = 1; currentLine <= oldLines.Length; ++currentLine)
                    {
                        if (currentLine == lineIndex)
                        {
                            sw.WriteLine(saveData);
                        }
                        else
                        {
                            sw.WriteLine(oldLines[currentLine - 1]);
                        }
                    }
                    Debug.Log("Save successfull!");
                }
            }
        }
        public static string LoadString(string filePath, int lineIndex)
        {
            string output = "";

            string[] allLines = File.ReadAllLines(filePath);

            using (StreamReader sr = new StreamReader(filePath))
            {
                for (int currentLine = 1; currentLine <= allLines.Length; currentLine++)
                {
                    if (currentLine == lineIndex)
                    {
                        output = allLines[currentLine - 1];
                    }
                }
            }
            return output;
        }
        public static float LoadFloat(string filePath, int lineIndex)
        {
            string output = "";

            string[] allLines = File.ReadAllLines(filePath);

            using (StreamReader sr = new StreamReader(filePath))
            {
                for (int currentLine = 1; currentLine <= allLines.Length; currentLine++)
                {
                    if (currentLine == lineIndex)
                    {
                        output = allLines[currentLine - 1];
                    }
                }
            }
            float _output = float.Parse(output);
            return _output;
        }
    }
	public class Search
	{
		//Used to check is a target is in front (!!Z-Axis only!!) of the origin.
		public static bool IsInFrontOf (Transform origin, Vector3 target)
		{
			Vector3 dir = (target - origin.transform.position).normalized;
			float direction = Vector3.Dot(dir, origin.forward);
			if(direction > 0.3f)
			{
				return true;	
			}
			else
			{
				return false;	
			}
		}
        //Used to check if a target is in front of the origin
        public static bool IsInFrontOf(Transform origin, Vector3 target, Vector3 forwardDirection)
        {
            Vector3 dir = (target - origin.transform.position).normalized;
            float direction = Vector3.Dot(dir, forwardDirection.normalized);
            if (direction > 0.3f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		/// <summary> outputs a list of gameObjects, that is in front of the origin with the given searchTag.
		public static List<GameObject> GameObjectsInFrontOf (string searchTag, Transform origin)
		{
			List<GameObject> output = new List<GameObject>();
			output.Clear();
			GameObject[] go = GameObject.FindGameObjectsWithTag(searchTag);
			foreach(GameObject goes in go)
			{
				if(IsInFrontOf(origin, goes.transform.position) == true)
				{
					output.Add(goes);
				}
			}
			return output;
		}
        /// <summary> outputs a list of gameObjects, that is in front of the origin with the given searchList.
        public static List<GameObject> GameObjectsInFrontOf(List<GameObject> searchList, Transform origin)
        {
            List<GameObject> output = new List<GameObject>();
            output.Clear();
            GameObject[] go = searchList.ToArray();
            foreach (GameObject goes in go)
            {
                if (IsInFrontOf(origin, goes.transform.position) == true)
                {
                    output.Add(goes);
                }
            }
            return output;
        }
		//The custom BroadRayCast function.
		public static bool BroadRayCast (Vector3 origin, float distance, Transform origin_Transform, out RaycastHit rayHit)
		{
            Vector3 fwd = origin_Transform.TransformDirection(Vector3.forward); //MidRay
            Vector3 fwd2 = origin_Transform.TransformDirection(new Vector3(0.2f, 0, 1)); //RightRays
            Vector3 fwd3 = origin_Transform.TransformDirection(new Vector3(0.4f, 0, 1));//RightRays
			Vector3 fwd4 = origin_Transform.TransformDirection(new Vector3(0.6f, 0, 1));//RightRays
            Vector3 fwd5 = origin_Transform.TransformDirection(new Vector3(0.8f, 0, 1));//RightRays
            Vector3 fwd6 = origin_Transform.TransformDirection(new Vector3(1, 0, 1));//RightRays

            Vector3 fwd7 = origin_Transform.TransformDirection(new Vector3(-0.2f, 0, 1));//LeftRays
            Vector3 fwd8 = origin_Transform.TransformDirection(new Vector3(-0.4f, 0, 1));//LeftRays
			Vector3 fwd9 = origin_Transform.TransformDirection(new Vector3(-0.6f, 0, 1));//RightRays
            Vector3 fwd10 = origin_Transform.TransformDirection(new Vector3(-0.8f, 0, 1));//LeftRays
            Vector3 fwd11 = origin_Transform.TransformDirection(new Vector3(-1, 0, 1));//LeftRays
			
			RaycastHit hit;
			RaycastHit hit2;
			RaycastHit hit3;
			RaycastHit hit4;
			RaycastHit hit5;
			RaycastHit hit6;
			RaycastHit hit7;
			RaycastHit hit8;
			RaycastHit hit9;
			RaycastHit hit10;
			RaycastHit hit11;
			
            //actual rays
            if (Physics.Raycast(origin_Transform.position, fwd, out hit, distance))
            {
				rayHit = new RaycastHit();
				rayHit = hit;
                return true;
            }
            else if (Physics.Raycast(origin_Transform.position, fwd2, out hit2, distance))
            {
                
                rayHit = new RaycastHit();
				rayHit = hit2;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd3, out hit3, distance))
            {
                
                rayHit = new RaycastHit();
				rayHit = hit3;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd4, out hit4, distance))
            {
                
               	rayHit = new RaycastHit();
				rayHit = hit4;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd5, out hit5, distance))
            {
                
                rayHit = new RaycastHit();
				rayHit = hit5;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd6, out hit6, distance))
            {
               
                rayHit = new RaycastHit();
				rayHit = hit6;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd7, out hit7, distance))
            {
                
                rayHit = new RaycastHit();
				rayHit = hit7;
				return true;
            }            
            else if (Physics.Raycast(origin_Transform.position, fwd8, out hit8, distance))
            {
                
                rayHit = new RaycastHit();
				rayHit = hit8;
				return true;
            }
            else if (Physics.Raycast(origin_Transform.position, fwd9, out hit9, distance))
            {
                
				rayHit = new RaycastHit();
				rayHit = hit9;
				return true;
            }
			else if (Physics.Raycast(origin_Transform.position, fwd10, out hit10, distance))
            {
                
				rayHit = new RaycastHit();
				rayHit = hit10;
				return true;
            }
			else if (Physics.Raycast(origin_Transform.position, fwd11, out hit11, distance))
            {
                
				rayHit = new RaycastHit();
				rayHit = hit11;
				return true;
            }
			else
			{
				rayHit = new RaycastHit();
				return false;
			}
		}
		//Finds the closest gameObject with the given searchTag.
		public static GameObject ClosestGameObject (Transform ClosestTo, string searchTag)
		{
			List<Transform> outPutList = new List<Transform>(); 
			outPutList.Clear();
			GameObject[] go = GameObject.FindGameObjectsWithTag(searchTag);
			foreach(GameObject goes in go)
			{
                if (goes != null)
				    outPutList.Add(goes.transform);
			}
			outPutList.Sort(delegate(Transform t1, Transform t2) {
					return Vector3.Distance(t1.position, ClosestTo.position).CompareTo(Vector3.Distance(t2.position, ClosestTo.position));
			});
			if(outPutList.Count > 0)
			{
				GameObject output = outPutList[0].gameObject;
				return output;
			}else
			{
				return null;	
			}
		}
		//Finds the closest gameObject with the given searchList.
		public static GameObject ClosestGameObject (Transform ClosestTo, List<GameObject> searchList)
		{	
			if(searchList.Count > 0)
			{
				List<Transform> sListTrs = new List<Transform>();
				sListTrs.Clear();
				foreach(GameObject go in searchList.ToArray())
				{
                    if(go != null)
					    sListTrs.Add(go.transform); 
				}
				sListTrs.Sort(delegate(Transform t1, Transform t2) {
						return Vector3.Distance(t1.position, ClosestTo.position).CompareTo(Vector3.Distance(t2.position, ClosestTo.position));
				});
                if (sListTrs.Count > 0)
                {
                    GameObject output = sListTrs[0].gameObject;
                    return output;
                }
                else
                    return null;
			}
			else
			{
				return null;	
			}
		}
		//Finds the closest gameObject with the given searchList.
        public static GameObject ClosestGameObject(Vector3 ClosestTo, List<GameObject> searchList)
        {
            if (searchList.Count > 0)
            {
                List<Transform> sListTrs = new List<Transform>();
                sListTrs.Clear();
                foreach (GameObject go in searchList.ToArray())
                {
                    if (go != null)
                        sListTrs.Add(go.transform);
                }
                sListTrs.Sort(delegate(Transform t1, Transform t2)
                {
                    return Vector3.Distance(t1.position, ClosestTo).CompareTo(Vector3.Distance(t2.position, ClosestTo));
                });
                if (sListTrs.Count > 0)
                {
                    GameObject output = sListTrs[0].gameObject;
                    return output;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
	}
	public class Movement
	{
		
	}
    public class StringTo
    {
        public static float ToFloat(string input)
        {
            float output = float.Parse(input);
            return output;
        }
    }
}