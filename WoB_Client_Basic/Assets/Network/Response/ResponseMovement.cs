using System;
using UnityEngine;

public class ResponseMovementEventArgs : ExtendedEventArgs 
{
   public float x {get; set;}
   public float y {get; set;}
   public float z {get; set;}

   public ResponseMovementEventArgs(){
       event_id = Constants.SMSG_MOVEMENT;
   }
}


public class ResponseMovement : NetworkResponse{

    private float x;
    private float y;
    private float z;

    public ResponseMovement(){

    }

    public override void parse(){
        x = DataReader.ReadFloat(dataStream);
        y = DataReader.ReadFloat(dataStream);   
        z = DataReader.ReadFloat(dataStream);
    }


    public override ExtendedEventArgs process(){
        ResponseMovementEventArgs args = null;
        args = new ResponseMovementEventArgs();
        args.x = x;
        args.y = y;
        args.z = z;
    
        return args;
    }
        
}
