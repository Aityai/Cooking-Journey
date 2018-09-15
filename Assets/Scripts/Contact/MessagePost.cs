
namespace Contact.Messages
{
    public enum MessagePost
    {

        // Use this for initialization
        none,
        error,
        //use for master
        master_next,
        master_wait,
        master_update,
        master_end,
        //use for system
        system_next,
        system_wait,
        system_update,
        //use for object
        object_next,
        object_update,
    }
}
