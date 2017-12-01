using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            int[] indexesToPlantBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] commandInput = Console.ReadLine().Split();

            int[] field = PlantBugsOnField(sizeField, indexesToPlantBugs);

            while (commandInput[0] != "end")
            {
                int bugIndex = int.Parse(commandInput[0]);
                string flightDirection = commandInput[1];
                int flightLength = int.Parse(commandInput[2]);

                flightDirection = CorrectFlightDirection(flightDirection, flightLength);

                //Checking if the index exists in the field:
                if (bugIndex >= 0 && bugIndex < sizeField)
                {
                    if (field[bugIndex] == 1) //checking if there is a ladybug on the index
                    {
                        field[bugIndex] = 0; //ladybug taking off and leaving index empty

                        //Landing left:
                        if (flightDirection == "left")
                        {
                            field = GetFieldAfterFlyingLeft(field, bugIndex, flightLength);
                        }

                        //Landing right:
                        if (flightDirection == "right")
                        {
                            field = GetFieldAfterFlyingRight(field, bugIndex, flightLength);
                        }
                    }
                }
                commandInput = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", field));
        }

        // --------------METHODS---------------- //

        //Third task: land, case right:
        private static int[] GetFieldAfterFlyingRight(int[] field, int bugIndex, int flightLength)
        {
            flightLength = Math.Abs(flightLength);

            for (int i = bugIndex + flightLength; i < field.Length; i += flightLength)
            {
                if (field[i] == 0)
                {
                    field[i] = 1;
                    break;
                }
            }
            return field;
        }

        //Third task: land, case left:
        private static int[] GetFieldAfterFlyingLeft(int[] field, int bugIndex, int flightLength)
        {
            flightLength = Math.Abs(flightLength);

            for (int i = bugIndex - flightLength; i >= 0; i -= flightLength)
            {
                if (field[i] == 0)
                {
                    field[i] = 1;
                    break;
                }
            }
            return field;
        }

        //Second task: determine left or right direciton based on - or + flightLength
        private static string CorrectFlightDirection(string flightDirection, int flightLength)
        {
            string correctedDirection = flightDirection;
            if (flightLength < 0)
            {
                switch (flightDirection)
                {
                    case "left":
                        correctedDirection = "right";
                        break;
                    case "right":
                        correctedDirection = "left";
                        break;
                }
            }
            return correctedDirection;
        }

        //First task: plant ladybugs in the field
        private static int[] PlantBugsOnField(int sizeField, int[] indexesToPlantBugs)
        {
            int[] field = new int[sizeField];
            for (int i = 0; i < indexesToPlantBugs.Length; i++)
            {
                if (indexesToPlantBugs[i] >= 0 && indexesToPlantBugs[i] < sizeField)
                {
                    field[indexesToPlantBugs[i]] = 1;
                }
            }
            return field;
        }
    }
}
