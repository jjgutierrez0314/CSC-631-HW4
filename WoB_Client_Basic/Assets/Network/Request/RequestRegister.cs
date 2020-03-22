﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestRegister : NetworkRequest {
    public RequestRegister () {
        request_id = Constants.CMSG_AUTH;
    }

    public void send (string username, string password) {
        packet = new GamePacket (request_id);
        packet.addString (Constants.CLIENT_VERSION);
        packet.addString (username);
        packet.addString (password);
    }
}