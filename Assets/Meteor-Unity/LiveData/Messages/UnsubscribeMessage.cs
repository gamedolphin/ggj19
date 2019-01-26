namespace Meteor.Internal
{
    internal class UnsubscribeMessage : Message
    {
        const string unsub = "unsub";

        public string id;

        public UnsubscribeMessage ()
        {
            msg = unsub;
        }
    }
}
