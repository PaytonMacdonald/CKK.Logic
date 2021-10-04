using System;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        // PROPERTIES
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value < 0)
                    throw new InvalidIdException();
                _id = value;
            }
        }
        public string Name { get; set; }
    }
}
