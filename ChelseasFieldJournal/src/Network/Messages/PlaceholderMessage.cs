using ProtoBuf;
using Vintagestory.API.MathTools;

namespace Ele.ChelseasFieldJournal;

public class PlaceholderMessage
{
    [ProtoContract]
    public class Request
    {
        [ProtoMember(1)]
        public BlockPos Position;
    }

    [ProtoContract]
    public class Response
    {
        [ProtoMember(1)]
        public Vec3d Position;
    }
}