using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IPositionnable
    {
        public int PositionX { get; }
        public int PositionY { get; }

        public char Symbol { get; }
    }
}
