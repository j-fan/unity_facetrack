class FaceOSC {
  OscP5 oscP5;
  NetAddress destination;
  
  // FaceOSC constructor, called when object is created
  FaceOSC(Object parent){
    // receive messages ar port 12000, currently unused
    oscP5 = new OscP5(parent,12000);
    // ip address and port to send messages to
    destination = new NetAddress("localhost",11000);
  }
  
  void sendFaceData() {
    
    /* OSC messages can be combination of data types like int, string, float
     * however the order of these data types must be extracted the same way
     * on the receiver (Unity)
     * For faceData the structure is:
     * - number of faces
     * - face id, x-coord, y-coord (repeated)
     * x and y coordinates are according to processing's pixel coordinates
     */
    
    OscMessage message = new OscMessage("/faceData");
    
    message.add(faceList.size());
    for(Face f : faceList){
      message.add(f.id);
      float xCentre = f.r.x + f.r.width*0.5;
      float yCentre = height/scl - (f.r.y + f.r.height*0.5); //flip y to match unity axis
      message.add(xCentre);
      message.add(yCentre);
    }
  
    /* send the message */
    oscP5.send(message, destination); 
  }  
}