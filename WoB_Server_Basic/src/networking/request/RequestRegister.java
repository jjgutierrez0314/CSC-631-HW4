package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameClient;
import core.GameServer;
import metadata.Constants;
import model.Player;
import networking.response.ResponseRegister;
import utility.DataReader;
import utility.Log; 

public class RequestRegister extends GameRequest {
    // Data
    private String version;
    private String user_id;
    private String password;
    // Responses
    private ResponseRegister responseLogin;

    public RequestRegister() {
        responses.add(responseLogin = new ResponseRegister());
    }

    @Override
    public void parse() throws IOException {
        version = DataReader.readString(dataInput).trim();
        user_id = DataReader.readString(dataInput).trim();
        password = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        
    }
}