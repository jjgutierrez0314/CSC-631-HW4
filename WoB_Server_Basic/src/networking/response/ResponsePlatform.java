package networking.response;

// Other Imports
import metadata.Constants;
import model.Platform;
import utility.GamePacket;

/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponsePlatform extends GameResponse {

    private Platform platform;

    public ResponsePlatform() {
         responseCode = Constants.SMSG_PLATFORM;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(platform.getX());
        packet.addInt32(platform.getY());
        packet.addInt32(platform.getZ());
        return packet.getBytes();
    }


    public void setPlatform(Platform platform) {
        this.platform = platform;
    }
}