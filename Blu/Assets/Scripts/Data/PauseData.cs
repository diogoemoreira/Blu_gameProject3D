using UnityEngine;

public static class Data {
    private static bool paused = false;

    public static void setPaused(bool status){
        paused=status;
    }

    public static bool getPaused(){
        return paused;
    }
}