package networking.response;

// Other Imports
import metadata.Constants;
import model.Platform;
import utility.GamePacket;
import utility.Log;

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
        packet.addInt32(platform.getY());
        Log.printf("Server ResponsePlatform has been sent to Client");
        return packet.getBytes();
    }


    public void setPlatform(Platform platform) {
        this.platform = platform;
    }
}