using UnityEngine;
using System.Collections;

namespace UnityEngine.UI
{
    public abstract class LoopScrollDataSource
    {
        public abstract void ProvideData(Transform transform, int idx);
    }

    public class LoopScrollSendIndexSource : LoopScrollDataSource
    {
        public static readonly LoopScrollSendIndexSource Instance = new LoopScrollSendIndexSource();

        LoopScrollSendIndexSource() { }

        public override void ProvideData(Transform transform, int idx)
        {
            //广播 传回当前滚动列表索引，控制数据更新
            transform.SendMessage("ScrollCellIndex",idx);
        }
    }

    public class LoopScrollArraySource<T> : LoopScrollDataSource
    {
        T[] objectsToFill;

        public LoopScrollArraySource(T[] objectsToFill)
        {
            this.objectsToFill = objectsToFill;
        }

        public override void ProvideData(Transform transform, int idx)
        {
            transform.SendMessage("ScrollCellContent", objectsToFill[idx]);
        }
    }
}