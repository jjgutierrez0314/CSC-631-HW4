using System;
using UnityEngine;

public class ResponsePlatformEventArgs : ExtendedEventArgs 
{
   public float y {get; set;}

   public ResponsePlatformEventArgs(){
       event_id = Constants.SMSG_PLATFORM;
   }
}


public class ResponsePlatform : NetworkResponse{

    private float y;

    public ResponsePlatform(){

    }

    public override void parse(){
        y = DataReader.ReadFloat(dataStream);   
    }


    public override ExtendedEventArgs process(){
        ResponsePlatformEventArgs args = null;
        args = new ResponsePlatformEventArgs();
        args.y = y;
        Debug.Log("Elevator position y: " + args.y);
        return args;
    }
        
}
