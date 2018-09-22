// custom data type to store information for a face
public class FaceData
{
    int faceId;
    float x;
    float y;
    public FaceData(int id, float x, float y)
    {
        faceId = id;
        this.x = x;
        this.y = y;
    }
    public float getX()
    {
        return x;
    }
    public float getY()
    {
        return y;
    }
    public int getID()
    {
        return faceId;
    }
}