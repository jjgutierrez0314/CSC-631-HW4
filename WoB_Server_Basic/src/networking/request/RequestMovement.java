package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Player;
import networking.response.ResponseLogin;
import networking.response.ResponseMovement;
import utility.DataReader;
import utility.Log;

public class RequestMovement extends GameRequest {

    private int x;
    private int y;
    private int z;

    private ResponseMovement responseMovement;

    public RequestMovement() {
        responses.add(responseMovement = new ResponseMovement());
    }

    @Override
    public void parse() throws IOException {
        x = DataReader.readInt(dataInput);
        y = DataReader.readInt(dataInput);
        z = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = new Player(x, y, z);
        client.setPlayer(player);
        responseMovement.setPlayer(player);
        Log.printf("Set player's coordinates");
    }
}