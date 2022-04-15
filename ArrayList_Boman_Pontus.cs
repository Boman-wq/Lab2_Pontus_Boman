using LaborationInterfaces;
using System;

namespace Boman_Pontus
{
    public class Laboration_2_ArrayList<TypeName> : ILaboration_2_List<TypeName>
    {
        private TypeName[] values = new TypeName[4];
        public int Size { get; private set; } = 0;

        public TypeName this[uint i]
        {
            get { return values[i]; }
            set { values[i] = value; }
        }
        public void AddFirst(TypeName data)
        {
            if (Size == values.Length)
                Grow();

            TypeName[] tempArray = new TypeName[values.Length];
            for (int i = 0; i <= Size; i++)
                if (i == 0)
                    tempArray[i] = data;
                else
                    tempArray[i] = values[i - 1];
            values = tempArray;
            Size++;
        }
        public void AddLast(TypeName data)
        {
            if (Size == values.Length)
                Grow();
            values[Size++] = data;
        }
        private void Grow()
        {
            int newSize = values.Length * 2;
            TypeName[] increaseSize = new TypeName[newSize];
            for(int i = 0; i < Size; i++)
                increaseSize[i] = values[i];
            values = increaseSize;
        }
        public int Count()
        {
            return Size;
        }
        public int IndexOf(TypeName target)
        {
            for (int i = 0; i < Size; i++)
                if (values[i].Equals(target))
                    return i;
            return -1;
        }
        public void Insert(uint index, TypeName data)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException($"Index: {index}, Size:{Size}");
            if (Size == values.Length)
                Grow();
            TypeName[] tempArray = new TypeName[values.Length];
            for (int i = 0; i <= Size; i++)
                if (i < index)
                    tempArray[i] = values[i];
                else if (i == index)
                    tempArray[i] = data;
                else
                    tempArray[i] = values[i - 1];
            values = tempArray;
            Size++;
        }
        public void Iterate(Action<TypeName> action)
        {
            for (int i = 0; i < Size; i++)
                action(values[i]);
        }
        public void RemoveAt(uint index)
        {
            if (index < 0 || index >= Size)
                throw new ArgumentOutOfRangeException($"Index:{index}, Size:{Size}");
            for (uint i = index; i < Size; i++)
                values[i] = values[i + 1];
            Size--;
        }
    }
}
