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
import java.util.ArrayList;

public class RequestRegister extends GameRequest {
    // Data
    private String version;
    private String user_id;
    private String password;
    // Responses
    private ResponseRegister responseRegister;

    //List of Players
    ArrayList<Player> playerList = new ArrayList<Player>();
    Player admin = new Player(100, "ilmi", "1111", (short) 1, 1000);
        
    public RequestRegister() {
        responses.add(responseRegister = new ResponseRegister());
    }

    @Override
    public void parse() throws IOException {
        version = DataReader.readString(dataInput).trim();
        user_id = DataReader.readString(dataInput).trim();
        password = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        if(!playerList.contains(admin)) {
            playerList.add(admin);
        }
        if (version.compareTo(Constants.CLIENT_VERSION) >= 0) {
            if (!user_id.isEmpty() && !password.isEmpty()) {
                Log.printf("User '%s' entered passwd '%s'", user_id, password);
                for(int i = 0; i < playerList.size(); i++) {
                    if(playerList.get(i).getUsername().equals(user_id)) {
                        Log.printf("Username '%s' is already taken", user_id);
                    } else {
                        Player player = new Player(100, user_id, password, (short) 1, 1000);
                        playerList.add(player);
                        Log.printf("'%s' is successfully registered!", user_id);
                        Log.printf(player.toString());
                        break;
                    }
                }
            }   
        }
    }
}