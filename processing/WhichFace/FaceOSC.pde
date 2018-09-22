class FaceOSC {
  OscP5 oscP5;
  NetAddress destination;
  
  // FaceOSC constructor, called when object is created
  FaceOSC(Object parent){
    // receive messages ar port 12000, currently unused
    oscP5 = new OscP5(parent,12000);
    // port to send messages to, must be same as "In Port" in Unity
    // 127.0.0.1 is the special address meaning the computer this is 
    // running on
    destination = new NetAddress("127.0.0.1",13000);
  }
  
  void sendFaceData() {
    // OSC messages can be a combination of data typrd likestrings, 
    // ints, floats etc.
    // However it has to be extracted by the OnRecieve() function
    // in Unity in the same order of data types that appear here.
    
    OscMessage myMessage = new OscMessage("/pc");
    myMessage.add(123); 
  
    /* send the message */
    oscP5.send(myMessage, destination); 
  }  
}