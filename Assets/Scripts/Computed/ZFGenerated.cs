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
            
            // Objects
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.InputDataFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>(structFormatter));
            }
            // Unions
            // Generics
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

    public class InputDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::InputData>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, bool> formatter0;
        readonly Formatter<TTypeResolver, bool> formatter1;
        readonly Formatter<TTypeResolver, bool> formatter2;
        readonly Formatter<TTypeResolver, bool> formatter3;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                ;
            }
        }

        public InputDataFormatter()
        {
            formatter0 = Formatter<TTypeResolver, bool>.Default;
            formatter1 = Formatter<TTypeResolver, bool>.Default;
            formatter2 = Formatter<TTypeResolver, bool>.Default;
            formatter3 = Formatter<TTypeResolver, bool>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::InputData value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Right);
            offset += formatter1.Serialize(ref bytes, offset, value.Left);
            offset += formatter2.Serialize(ref bytes, offset, value.Up);
            offset += formatter3.Serialize(ref bytes, offset, value.Down);
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
            
            return new global::InputData(item0, item1, item2, item3);
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



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
