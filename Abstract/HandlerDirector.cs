using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TG.Abstract;

public class HandlerDirector
{

    private Dictionary<UpdateType, IActionHandler> _map = new Dictionary<UpdateType, IActionHandler>();

    public HandlerDirector()
    {
        var instances =
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetTypes()
            where typeof(IActionHandler).IsAssignableFrom(type)
            where type.IsAbstract is false
            where type.IsInterface is false
            select Activator.CreateInstance(type) as IActionHandler;


        foreach (var instance in instances)
        {
            _map.Add(instance.HandledType, instance);
        }
    }
    public IActionHandler this[UpdateType t]
    {
        get
        {
            if (_map.ContainsKey(t) is false)
            {
                //todo return UnkownCommandHandler
                return _map[UpdateType.Unknown];
            }
            return _map[t];
        }
        internal set
        {
            _map[t] = value;
        }
    }
}