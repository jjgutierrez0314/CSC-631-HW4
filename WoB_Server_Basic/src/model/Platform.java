package model;

// Other Imports
import core.GameClient;

/**
 * The Player class holds important information about the player including, most
 * importantly, the account. Such information includes the username, password,
 * email, and the player ID.
 */
public class Platform {
    private int platform_id;
    private int y;

    // public Platform(int platform_id) {
    //     this.platform_id = platform_id;
    // }

    public Platform(int y) {
        this.y = y;
    }
    public int getY () {
        return y;
    }

    public int setY (int y) {
        return this.y = y;
    }

    // public int getID() {
    //     return platform_id;
    // }

    // public int setID(int platform_id) {
    //     return this.platform_id = platform_id;
    // }

   
    // public GameClient getClient() {
    //     return client;
    // }

    // public GameClient setClient(GameClient client) {
    //     return this.client = client;
    // }

    @Override
    public String toString() {
        return "Platform{" +
                // "platform_id=" + platform_id +
                // ", x ='" + x + '\'' +
                ", y ='" + y + '\'' +
                // ", z =" + z +
                '}';
    }
}
