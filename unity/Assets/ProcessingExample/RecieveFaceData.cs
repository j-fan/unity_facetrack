using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveFaceData : MonoBehaviour {

    // Create the OSC object (1 per scene) by creating
    // a empty game object, add the OSC.cs script
    // and select it in any other object that requires
    // OSC data, like this one
    public OSC osc;

    List<FaceData> faces;
    GameObject[] balls;

    // Use this for initialization
    void Start() {
        faces = new List<FaceData>();
        createBalls();
        osc.SetAllMessageHandler(OnReceive);
    }

    void createBalls()
    {
        int count = 10;
        balls = new GameObject[count]; // up to 10 balls move according to faces tracked
        for (int i=0;i<count;i++)
        {
            balls[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            balls[i].transform.localScale = new Vector3(10, 10, 10);
        }
    }

    /* For faceData the structure is:
     * - number of faces
     * - face id, x-coord, y-coord(repeated)
     * x and y coordinates are according to processing's pixel coordinates
     */
    void OnReceive(OscMessage message)
    {
        int numFaces = message.GetInt(0);
        faces = new List<FaceData>();
        for (int i = 0; i < numFaces; i++)
        {
            int faceID = message.GetInt(i * 3 + 1);
            float xCoord = message.GetFloat(i * 3 + 2);
            float yCoord = message.GetFloat(i * 3 + 3);
            
            FaceData face = new FaceData(faceID, xCoord, yCoord);
            faces.Add(face);

            print(faceID + " " + xCoord + " " + yCoord);
        }
    }

    // Update is called once per frame
    void Update() {
        //move the balls to where the faces are
        for(int i=0;i<faces.Count; i++)
        {
            // stop if there are more faces than balls
            if(i > balls.Length - 1)
            {
                break;
            }
            balls[i].transform.position = new Vector3(faces[i].getX(), faces[i].getY(), 0);
        }

    }

}
