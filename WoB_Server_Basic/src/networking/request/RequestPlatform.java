package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Platform;
import networking.response.ResponsePlatform;
import utility.DataReader;
import utility.Log;

public class RequestPlatform extends GameRequest {

    private int y;

    private ResponsePlatform responsePlatform;

    public RequestPlatform() {
        responses.add(responsePlatform = new ResponsePlatform());
    }

    @Override
    public void parse() throws IOException {
        y = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        
        Platform platform = new Platform(y);
        Log.printf("Server Platform y:%d", y);
        responsePlatform.setPlatform(platform);

    }
}