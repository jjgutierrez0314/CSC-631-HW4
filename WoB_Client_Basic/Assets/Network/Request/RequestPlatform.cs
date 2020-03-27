using System;
using UnityEngine;

public class RequestPlatform : NetworkRequest {
    public RequestPlatform () {
        request_id = Constants.CMSG_PLATFORM;
    }

    public void send (float y) {
        packet = new GamePacket (request_id);
        packet.addInt32 ((int) y);
    }
}