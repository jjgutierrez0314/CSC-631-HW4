package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseMovement extends GameResponse {

    private Player player;

    public ResponseMovement() {
        responseCode = Constants.SMSG_MOVEMENT;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getX());
        packet.addInt32(player.getY());
        packet.addInt32(player.getZ());
        return packet.getBytes();
    }


    public void setPlayer(Player player) {
        this.player = player;
    }
}