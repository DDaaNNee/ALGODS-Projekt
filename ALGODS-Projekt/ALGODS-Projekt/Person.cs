using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    public class Person
    {
        public Person(int start_floor, int end_floor)
        {
            _Start_floor = start_floor;
            _End_floor = end_floor;
            _Time = 0;
        }
        
        
        // Properties. Looked up how to use properties in Essential C# 6.0 by Mark Michaelis and Eric Lippert, p. 237 - 240.
        
        public int Start_floor
        {
            get 
            {
                return _Start_floor;
            }
            set
            {
                _Start_floor = value;
            }
        }
        private int _Start_floor;
        
        public int End_floor
        {
            get
            {
                return _End_floor;
            }
            set
            {
                _End_floor = value;
            }
        }
        private int _End_floor;
        
        public int Time 
        {
            get
            {
                return _Time;
            }
            set 
            {
                _Time = value;
            }
        }
        private int _Time;
        
        
    }
}
