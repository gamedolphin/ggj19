#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        static bool registered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(registered) return;
            registered = true;
            // Enums
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::GameType>.Register(new ZeroFormatter.DynamicObjectSegments.GameTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::GameType>.Register(new ZeroFormatter.DynamicObjectSegments.GameTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::GameType?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableGameTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::GameType?>.Register(new NullableEqualityComparer<global::GameType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ClientEntityTypes>.Register(new ZeroFormatter.DynamicObjectSegments.ClientEntityTypesFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ClientEntityTypes>.Register(new ZeroFormatter.DynamicObjectSegments.ClientEntityTypesEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ClientEntityTypes?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableClientEntityTypesFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ClientEntityTypes?>.Register(new NullableEqualityComparer<global::ClientEntityTypes>());
            
            // Objects
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::WorldState>.Register(new ZeroFormatter.DynamicObjectSegments.WorldStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Vector3SimFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Vector3Sim>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Vector3Sim?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Vector3Sim>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.PlayerStateFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::PlayerState>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::PlayerState?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::PlayerState>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.InputDataFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>(structFormatter));
            }
            // Unions
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::PlayerState>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class WorldStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::WorldState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::WorldState value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(ref bytes, startOffset, offset, 0, value.PlayerList);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::WorldState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WorldStateObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WorldStateObjectSegment<TTypeResolver> : global::WorldState, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<global::PlayerState> _PlayerList;

        // 0
        public override global::System.Collections.Generic.IList<global::PlayerState> PlayerList
        {
            get
            {
                return _PlayerList;
            }
            set
            {
                __tracker.Dirty();
                _PlayerList = value;
            }
        }


        public WorldStateObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _PlayerList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(originalBytes, 0, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(ref targetBytes, startOffset, offset, 0, _PlayerList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class Vector3SimFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Vector3Sim>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Vector3SimFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Vector3Sim value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            offset += formatter2.Serialize(ref bytes, offset, value.z);
            return offset - startOffset;
        }

        public override global::Vector3Sim Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Vector3Sim(item0, item1, item2);
        }
    }

    public class PlayerStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::PlayerState>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, long> formatter0;
        readonly Formatter<TTypeResolver, global::Vector3Sim> formatter1;
        readonly Formatter<TTypeResolver, long> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public PlayerStateFormatter()
        {
            formatter0 = Formatter<TTypeResolver, long>.Default;
            formatter1 = Formatter<TTypeResolver, global::Vector3Sim>.Default;
            formatter2 = Formatter<TTypeResolver, long>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::PlayerState value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Id);
            offset += formatter1.Serialize(ref bytes, offset, value.Position);
            offset += formatter2.Serialize(ref bytes, offset, value.Index);
            return offset - startOffset;
        }

        public override global::PlayerState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::PlayerState(item0, item1, item2);
        }
    }

    public class InputDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::InputData>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, bool> formatter0;
        readonly Formatter<TTypeResolver, bool> formatter1;
        readonly Formatter<TTypeResolver, bool> formatter2;
        readonly Formatter<TTypeResolver, bool> formatter3;
        readonly Formatter<TTypeResolver, long> formatter4;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                    && formatter4.NoUseDirtyTracker
                ;
            }
        }

        public InputDataFormatter()
        {
            formatter0 = Formatter<TTypeResolver, bool>.Default;
            formatter1 = Formatter<TTypeResolver, bool>.Default;
            formatter2 = Formatter<TTypeResolver, bool>.Default;
            formatter3 = Formatter<TTypeResolver, bool>.Default;
            formatter4 = Formatter<TTypeResolver, long>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::InputData value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Right);
            offset += formatter1.Serialize(ref bytes, offset, value.Left);
            offset += formatter2.Serialize(ref bytes, offset, value.Up);
            offset += formatter3.Serialize(ref bytes, offset, value.Down);
            offset += formatter4.Serialize(ref bytes, offset, value.Index);
            return offset - startOffset;
        }

        public override global::InputData Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = formatter4.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::InputData(item0, item1, item2, item3, item4);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class GameTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::GameType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::GameType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::GameType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::GameType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableGameTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::GameType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::GameType? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::GameType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::GameType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class GameTypeEqualityComparer : IEqualityComparer<global::GameType>
    {
        public bool Equals(global::GameType x, global::GameType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::GameType x)
        {
            return (int)x;
        }
    }



    public class ClientEntityTypesFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ClientEntityTypes>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ClientEntityTypes value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::ClientEntityTypes Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::ClientEntityTypes)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableClientEntityTypesFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ClientEntityTypes?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ClientEntityTypes? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::ClientEntityTypes? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ClientEntityTypes)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class ClientEntityTypesEqualityComparer : IEqualityComparer<global::ClientEntityTypes>
    {
        public bool Equals(global::ClientEntityTypes x, global::ClientEntityTypes y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::ClientEntityTypes x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
