//show gameplay
//logic in game
//map input handle on play game
namespace Contact.Messages
{

    public enum MessageSystem
    {
        none,
        error,
        update,
        first,
        //on play game
        click,
        select,
        hold,
        unpress,
        drag,

        //handle
        move,
        up,
        down,
        left,
        right,
        Fire,
        Shoot,
        //Touch

        //local Data control
        localWrite,
        localRead,
        localUpdate,
        LocalLoading,
        //cloud Data control
        cloundSynx,
        cloundDiff,
        cloundPull,
        cloundPush,
        cloundWait,

    }
}
