using System;

namespace VogalUnica
{
    public class Manipulate : IStream
    {
        private int currentChar { get; set; }
        private string stream { get; set; }

        public Manipulate(string str)
        {
            stream = str;
        }

        public char getNext()
        {
            if (hasNext())
            {
                char retorno = Convert.ToChar(stream.Substring(currentChar, 1));
                currentChar++;
                return retorno;
            }
            else
                return char.MinValue;
        }

        public bool hasNext()
        {
            if (stream.Length > currentChar)
                return true;
            else
                return false;
        }
    }
}
