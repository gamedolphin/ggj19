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
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_BrushMirror>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_BrushMirrorFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_BrushMirror>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_BrushMirrorEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_BrushMirror?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_BrushMirrorFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_BrushMirror?>.Register(new NullableEqualityComparer<global::Polybrush.z_BrushMirror>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ComponentIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ComponentIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ComponentIndex>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ComponentIndexEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ComponentIndex?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_ComponentIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ComponentIndex?>.Register(new NullableEqualityComparer<global::Polybrush.z_ComponentIndex>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ComponentIndexType>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ComponentIndexTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ComponentIndexType>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ComponentIndexTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ComponentIndexType?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_ComponentIndexTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ComponentIndexType?>.Register(new NullableEqualityComparer<global::Polybrush.z_ComponentIndexType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.Culling>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.CullingFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.Culling>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.CullingEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.Culling?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.NullableCullingFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.Culling?>.Register(new NullableEqualityComparer<global::Polybrush.Culling>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_Direction>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_DirectionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_Direction>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_DirectionEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_Direction?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_DirectionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_Direction?>.Register(new NullableEqualityComparer<global::Polybrush.z_Direction>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_MeshChannel>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_MeshChannelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_MeshChannel>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_MeshChannelEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_MeshChannel?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_MeshChannelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_MeshChannel?>.Register(new NullableEqualityComparer<global::Polybrush.z_MeshChannel>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_MirrorCoordinateSpace>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_MirrorCoordinateSpaceFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_MirrorCoordinateSpace>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_MirrorCoordinateSpaceEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_MirrorCoordinateSpace?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_MirrorCoordinateSpaceFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_MirrorCoordinateSpace?>.Register(new NullableEqualityComparer<global::Polybrush.z_MirrorCoordinateSpace>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ModelSource>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ModelSourceFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ModelSource>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_ModelSourceEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_ModelSource?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_ModelSourceFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_ModelSource?>.Register(new NullableEqualityComparer<global::Polybrush.z_ModelSource>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_PaintMode>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_PaintModeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_PaintMode>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_PaintModeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_PaintMode?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_PaintModeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_PaintMode?>.Register(new NullableEqualityComparer<global::Polybrush.z_PaintMode>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_PlacementDirection>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_PlacementDirectionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_PlacementDirection>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_PlacementDirectionEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_PlacementDirection?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_PlacementDirectionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_PlacementDirection?>.Register(new NullableEqualityComparer<global::Polybrush.z_PlacementDirection>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_SelectionRenderState>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_SelectionRenderStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_SelectionRenderState>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.z_SelectionRenderStateEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Polybrush.z_SelectionRenderState?>.Register(new ZeroFormatter.DynamicObjectSegments.Polybrush.Nullablez_SelectionRenderStateFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Polybrush.z_SelectionRenderState?>.Register(new NullableEqualityComparer<global::Polybrush.z_SelectionRenderState>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ProGrids.Axis>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.AxisFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ProGrids.Axis>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.AxisEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ProGrids.Axis?>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.NullableAxisFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ProGrids.Axis?>.Register(new NullableEqualityComparer<global::ProGrids.Axis>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ProGrids.SnapUnit>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.SnapUnitFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ProGrids.SnapUnit>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.SnapUnitEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ProGrids.SnapUnit?>.Register(new ZeroFormatter.DynamicObjectSegments.ProGrids.NullableSnapUnitFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ProGrids.SnapUnit?>.Register(new NullableEqualityComparer<global::ProGrids.SnapUnit>());
            
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
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.QuestInfoFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::QuestInfo>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::QuestInfo?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::QuestInfo>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.EnemyInfoFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::EnemyInfo>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::EnemyInfo?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::EnemyInfo>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.InputDataFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::InputData>(structFormatter));
            }
            // Unions
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::EnemyInfo>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::PlayerState>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::QuestInfo>();
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

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(ref bytes, startOffset, offset, 0, value.PlayerList);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::QuestInfo>>(ref bytes, startOffset, offset, 1, value.QuestList);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::EnemyInfo>>(ref bytes, startOffset, offset, 2, value.EnemyList);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
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
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<global::PlayerState> _PlayerList;
        global::System.Collections.Generic.IList<global::QuestInfo> _QuestList;
        global::System.Collections.Generic.IList<global::EnemyInfo> _EnemyList;

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

        // 1
        public override global::System.Collections.Generic.IList<global::QuestInfo> QuestList
        {
            get
            {
                return _QuestList;
            }
            set
            {
                __tracker.Dirty();
                _QuestList = value;
            }
        }

        // 2
        public override global::System.Collections.Generic.IList<global::EnemyInfo> EnemyList
        {
            get
            {
                return _EnemyList;
            }
            set
            {
                __tracker.Dirty();
                _EnemyList = value;
            }
        }


        public WorldStateObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _PlayerList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(originalBytes, 0, __binaryLastIndex, __tracker);
            _QuestList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::QuestInfo>>(originalBytes, 1, __binaryLastIndex, __tracker);
            _EnemyList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::EnemyInfo>>(originalBytes, 2, __binaryLastIndex, __tracker);
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
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::PlayerState>>(ref targetBytes, startOffset, offset, 0, _PlayerList);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::QuestInfo>>(ref targetBytes, startOffset, offset, 1, _QuestList);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::EnemyInfo>>(ref targetBytes, startOffset, offset, 2, _EnemyList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
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
        readonly Formatter<TTypeResolver, int> formatter0;
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
            formatter0 = Formatter<TTypeResolver, int>.Default;
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
            offset += formatter0.Serialize(ref bytes, offset, value.Hashcode);
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

    public class QuestInfoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::QuestInfo>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, string> formatter0;
        readonly Formatter<TTypeResolver, global::Vector3Sim> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        readonly Formatter<TTypeResolver, int> formatter3;
        
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

        public QuestInfoFormatter()
        {
            formatter0 = Formatter<TTypeResolver, string>.Default;
            formatter1 = Formatter<TTypeResolver, global::Vector3Sim>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            formatter3 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::QuestInfo value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.QuestName);
            offset += formatter1.Serialize(ref bytes, offset, value.Position);
            offset += formatter2.Serialize(ref bytes, offset, value.Health);
            offset += formatter3.Serialize(ref bytes, offset, value.Id);
            return offset - startOffset;
        }

        public override global::QuestInfo Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
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
            
            return new global::QuestInfo(item0, item1, item2, item3);
        }
    }

    public class EnemyInfoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::EnemyInfo>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, string> formatter0;
        readonly Formatter<TTypeResolver, global::Vector3Sim> formatter1;
        readonly Formatter<TTypeResolver, int> formatter2;
        
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

        public EnemyInfoFormatter()
        {
            formatter0 = Formatter<TTypeResolver, string>.Default;
            formatter1 = Formatter<TTypeResolver, global::Vector3Sim>.Default;
            formatter2 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::EnemyInfo value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.EnemyName);
            offset += formatter1.Serialize(ref bytes, offset, value.Position);
            offset += formatter2.Serialize(ref bytes, offset, value.Id);
            return offset - startOffset;
        }

        public override global::EnemyInfo Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
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
            
            return new global::EnemyInfo(item0, item1, item2);
        }
    }

    public class InputDataFormatter<TTypeResolver> : Formatter<TTypeResolver, global::InputData>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, bool> formatter0;
        readonly Formatter<TTypeResolver, bool> formatter1;
        readonly Formatter<TTypeResolver, bool> formatter2;
        readonly Formatter<TTypeResolver, bool> formatter3;
        readonly Formatter<TTypeResolver, bool> formatter4;
        readonly Formatter<TTypeResolver, long> formatter5;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                    && formatter4.NoUseDirtyTracker
                    && formatter5.NoUseDirtyTracker
                ;
            }
        }

        public InputDataFormatter()
        {
            formatter0 = Formatter<TTypeResolver, bool>.Default;
            formatter1 = Formatter<TTypeResolver, bool>.Default;
            formatter2 = Formatter<TTypeResolver, bool>.Default;
            formatter3 = Formatter<TTypeResolver, bool>.Default;
            formatter4 = Formatter<TTypeResolver, bool>.Default;
            formatter5 = Formatter<TTypeResolver, long>.Default;
            
        }

        public override int? GetLength()
        {
            return 13;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::InputData value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Right);
            offset += formatter1.Serialize(ref bytes, offset, value.Left);
            offset += formatter2.Serialize(ref bytes, offset, value.Up);
            offset += formatter3.Serialize(ref bytes, offset, value.Down);
            offset += formatter4.Serialize(ref bytes, offset, value.Interact);
            offset += formatter5.Serialize(ref bytes, offset, value.Index);
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
            var item5 = formatter5.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::InputData(item0, item1, item2, item3, item4, item5);
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
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Polybrush
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class z_BrushMirrorFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_BrushMirror>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_BrushMirror value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_BrushMirror Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_BrushMirror)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_BrushMirrorFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_BrushMirror?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_BrushMirror? value)
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

        public override global::Polybrush.z_BrushMirror? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_BrushMirror)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_BrushMirrorEqualityComparer : IEqualityComparer<global::Polybrush.z_BrushMirror>
    {
        public bool Equals(global::Polybrush.z_BrushMirror x, global::Polybrush.z_BrushMirror y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_BrushMirror x)
        {
            return (int)x;
        }
    }



    public class z_ComponentIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ComponentIndex>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ComponentIndex value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_ComponentIndex Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_ComponentIndex)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_ComponentIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ComponentIndex?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ComponentIndex? value)
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

        public override global::Polybrush.z_ComponentIndex? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_ComponentIndex)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_ComponentIndexEqualityComparer : IEqualityComparer<global::Polybrush.z_ComponentIndex>
    {
        public bool Equals(global::Polybrush.z_ComponentIndex x, global::Polybrush.z_ComponentIndex y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_ComponentIndex x)
        {
            return (int)x;
        }
    }



    public class z_ComponentIndexTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ComponentIndexType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ComponentIndexType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_ComponentIndexType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_ComponentIndexType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_ComponentIndexTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ComponentIndexType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ComponentIndexType? value)
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

        public override global::Polybrush.z_ComponentIndexType? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_ComponentIndexType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_ComponentIndexTypeEqualityComparer : IEqualityComparer<global::Polybrush.z_ComponentIndexType>
    {
        public bool Equals(global::Polybrush.z_ComponentIndexType x, global::Polybrush.z_ComponentIndexType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_ComponentIndexType x)
        {
            return (int)x;
        }
    }



    public class CullingFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.Culling>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.Culling value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.Culling Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.Culling)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableCullingFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.Culling?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.Culling? value)
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

        public override global::Polybrush.Culling? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.Culling)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class CullingEqualityComparer : IEqualityComparer<global::Polybrush.Culling>
    {
        public bool Equals(global::Polybrush.Culling x, global::Polybrush.Culling y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.Culling x)
        {
            return (int)x;
        }
    }



    public class z_DirectionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_Direction>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_Direction value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_Direction Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_Direction)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_DirectionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_Direction?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_Direction? value)
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

        public override global::Polybrush.z_Direction? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_Direction)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_DirectionEqualityComparer : IEqualityComparer<global::Polybrush.z_Direction>
    {
        public bool Equals(global::Polybrush.z_Direction x, global::Polybrush.z_Direction y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_Direction x)
        {
            return (int)x;
        }
    }



    public class z_MeshChannelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_MeshChannel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_MeshChannel value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_MeshChannel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_MeshChannel)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_MeshChannelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_MeshChannel?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_MeshChannel? value)
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

        public override global::Polybrush.z_MeshChannel? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_MeshChannel)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_MeshChannelEqualityComparer : IEqualityComparer<global::Polybrush.z_MeshChannel>
    {
        public bool Equals(global::Polybrush.z_MeshChannel x, global::Polybrush.z_MeshChannel y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_MeshChannel x)
        {
            return (int)x;
        }
    }



    public class z_MirrorCoordinateSpaceFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_MirrorCoordinateSpace>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_MirrorCoordinateSpace value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_MirrorCoordinateSpace Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_MirrorCoordinateSpace)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_MirrorCoordinateSpaceFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_MirrorCoordinateSpace?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_MirrorCoordinateSpace? value)
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

        public override global::Polybrush.z_MirrorCoordinateSpace? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_MirrorCoordinateSpace)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_MirrorCoordinateSpaceEqualityComparer : IEqualityComparer<global::Polybrush.z_MirrorCoordinateSpace>
    {
        public bool Equals(global::Polybrush.z_MirrorCoordinateSpace x, global::Polybrush.z_MirrorCoordinateSpace y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_MirrorCoordinateSpace x)
        {
            return (int)x;
        }
    }



    public class z_ModelSourceFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ModelSource>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ModelSource value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_ModelSource Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_ModelSource)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_ModelSourceFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_ModelSource?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_ModelSource? value)
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

        public override global::Polybrush.z_ModelSource? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_ModelSource)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_ModelSourceEqualityComparer : IEqualityComparer<global::Polybrush.z_ModelSource>
    {
        public bool Equals(global::Polybrush.z_ModelSource x, global::Polybrush.z_ModelSource y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_ModelSource x)
        {
            return (int)x;
        }
    }



    public class z_PaintModeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_PaintMode>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_PaintMode value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_PaintMode Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_PaintMode)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_PaintModeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_PaintMode?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_PaintMode? value)
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

        public override global::Polybrush.z_PaintMode? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_PaintMode)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_PaintModeEqualityComparer : IEqualityComparer<global::Polybrush.z_PaintMode>
    {
        public bool Equals(global::Polybrush.z_PaintMode x, global::Polybrush.z_PaintMode y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_PaintMode x)
        {
            return (int)x;
        }
    }



    public class z_PlacementDirectionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_PlacementDirection>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_PlacementDirection value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_PlacementDirection Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_PlacementDirection)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_PlacementDirectionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_PlacementDirection?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_PlacementDirection? value)
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

        public override global::Polybrush.z_PlacementDirection? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_PlacementDirection)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_PlacementDirectionEqualityComparer : IEqualityComparer<global::Polybrush.z_PlacementDirection>
    {
        public bool Equals(global::Polybrush.z_PlacementDirection x, global::Polybrush.z_PlacementDirection y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_PlacementDirection x)
        {
            return (int)x;
        }
    }



    public class z_SelectionRenderStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_SelectionRenderState>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_SelectionRenderState value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Polybrush.z_SelectionRenderState Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Polybrush.z_SelectionRenderState)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class Nullablez_SelectionRenderStateFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Polybrush.z_SelectionRenderState?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Polybrush.z_SelectionRenderState? value)
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

        public override global::Polybrush.z_SelectionRenderState? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Polybrush.z_SelectionRenderState)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class z_SelectionRenderStateEqualityComparer : IEqualityComparer<global::Polybrush.z_SelectionRenderState>
    {
        public bool Equals(global::Polybrush.z_SelectionRenderState x, global::Polybrush.z_SelectionRenderState y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Polybrush.z_SelectionRenderState x)
        {
            return (int)x;
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
namespace ZeroFormatter.DynamicObjectSegments.ProGrids
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class AxisFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ProGrids.Axis>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ProGrids.Axis value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::ProGrids.Axis Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::ProGrids.Axis)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableAxisFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ProGrids.Axis?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ProGrids.Axis? value)
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

        public override global::ProGrids.Axis? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ProGrids.Axis)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class AxisEqualityComparer : IEqualityComparer<global::ProGrids.Axis>
    {
        public bool Equals(global::ProGrids.Axis x, global::ProGrids.Axis y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::ProGrids.Axis x)
        {
            return (int)x;
        }
    }



    public class SnapUnitFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ProGrids.SnapUnit>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ProGrids.SnapUnit value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::ProGrids.SnapUnit Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::ProGrids.SnapUnit)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableSnapUnitFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ProGrids.SnapUnit?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ProGrids.SnapUnit? value)
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

        public override global::ProGrids.SnapUnit? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ProGrids.SnapUnit)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class SnapUnitEqualityComparer : IEqualityComparer<global::ProGrids.SnapUnit>
    {
        public bool Equals(global::ProGrids.SnapUnit x, global::ProGrids.SnapUnit y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::ProGrids.SnapUnit x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
