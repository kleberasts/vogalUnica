using System;

namespace VogalUnica
{
    public interface IStream
    {
        char getNext();
        Boolean hasNext();
    }
}