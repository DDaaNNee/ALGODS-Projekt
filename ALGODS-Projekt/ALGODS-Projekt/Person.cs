using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGODS_Projekt
{
    public class Person
    {
        // Constructor
        public Person(int start_floor, int end_floor)
        {
            _Start_floor = start_floor;
            _End_floor = end_floor;
            _Waiting_time = 0;
            _System_time = 0;
            _DirectionInt = start_floor - end_floor;
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
        
       // Time that the person has been waiting for the elevator.
       public int Waiting_time
       {  
            get
            {
                return _Waiting_time;
            }
            set
            {
                 _Waiting_time = value;       
            }
       }
        private int _Waiting_time;
        
        // Time that the person has been in the elevator.
        public int System_time 
        {
            get 
            {
                return _System_time;
            }
            set 
            {
                _System_time = value;
            }
        }
        private int _System_time;


        public int DirectionInt
        {
            get
            {
                return _DirectionInt;
            }
            set
            {
                _DirectionInt = value;
            }
        }
        private int _DirectionInt;

        // Methods:

        // Get total time
        public int GetCompletionTime()
        {
            return _Waiting_time + _System_time;
        }

        public Direction.DirectionEnum GetDirection(int starting_floor, int ending_floor)
        {
            Direction.DirectionEnum currentDirection;

            if (_DirectionInt < 0)
            {
                currentDirection = Direction.DirectionEnum.Up;
                return currentDirection;
            }
            else if (_DirectionInt > 0)
            {
                currentDirection = Direction.DirectionEnum.Down;
                return currentDirection;
            }
            else
            {
                currentDirection = Direction.DirectionEnum.Neutral;
                return currentDirection;
            }
        }
        
        
        
        
        
    }
}
