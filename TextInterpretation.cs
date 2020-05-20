using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asgn
{
    /*this class to do the convert this compressed binary stream into alphanumerics */
    public class TextInterpretation
    {
        public string Interpertation(DAABitArray inDAABitArray)
        {
            string output = "";

            
            /*how many bits are from the DAABitArray*/
            int numBit = inDAABitArray.NumBits;
            /*for every 6 bits from the DAABitArray need to be converted*/
            long bitRange;
            for (int i = 0; i < numBit - 5; i += 6)
            {
                bitRange = inDAABitArray.GetBitRange(i, i + 5);
                output += Selection(bitRange);
            }
            /*add the bits if the number of bit is not multiple of 6*/
            int shiftNum, startPoint;
            long addBit = 0;
            if (numBit % 6 != 0)
            {
                /*check how many bits we need fill in*/
                startPoint = numBit - numBit % 6;

                /*check where it need start fill in*/
                shiftNum = 6 - numBit % 6;

                /*call the function form the DAABitarray to fill in*/
                addBit = inDAABitArray.GetBitRange(startPoint, numBit - 1);

                output += Selection(addBit << shiftNum);
            }



            return output;

        }
        /*when the bits import in, check the correct symbol need to convert*/
        char Selection(long inBits)
        {
            char printChar = ' ';
            switch (inBits)
            {
                case 0:
                    printChar = ' ';
                    break;
                case 1:
                    printChar = 'A';
                    break;
                case 2:
                    printChar = 'B';
                    break;
                case 3:
                    printChar = 'C';
                    break;
                case 4:
                    printChar = 'D';
                    break;
                case 5:
                    printChar = 'E';
                    break;
                case 6:
                    printChar = 'F';
                    break;
                case 7:
                    printChar = 'G';
                    break;
                case 8:
                    printChar = 'h';
                    break;
                case 9:
                    printChar = 'I';
                    break;
                case 10:
                    printChar = 'J';
                    break;
                case 11:
                    printChar = 'K';
                    break;
                case 12:
                    printChar = 'L';
                    break;
                case 13:
                    printChar = 'M';
                    break;
                case 14:
                    printChar = 'N';
                    break;
                case 15:
                    printChar = 'O';
                    break;
                case 16:
                    printChar = 'P';
                    break;
                case 17:
                    printChar = 'Q';
                    break;
                case 18:
                    printChar = 'R';
                    break;
                case 19:
                    printChar = 'S';
                    break;
                case 20:
                    printChar = 'T';
                    break;
                case 21:
                    printChar = 'U';
                    break;
                case 22:
                    printChar = 'V';
                    break;
                case 23:
                    printChar = 'W';
                    break;
                case 24:
                    printChar = 'X';
                    break;
                case 25:
                    printChar = 'Y';
                    break;
                case 26:
                    printChar = 'Z';
                    break;
                case 27:
                    printChar = 'a';
                    break;
                case 28:
                    printChar = 'b';
                    break;
                case 29:
                    printChar = 'c';
                    break;
                case 30:
                    printChar = 'd';
                    break;
                case 31:
                    printChar = 'e';
                    break;
                case 32:
                    printChar = 'f';
                    break;
                case 33:
                    printChar = 'g';
                    break;
                case 34:
                    printChar = 'h';
                    break;
                case 35:
                    printChar = 'i';
                    break;
                case 36:
                    printChar = 'j';
                    break;
                case 37:
                    printChar = 'k';
                    break;
                case 38:
                    printChar = 'l';
                    break;
                case 39:
                    printChar = 'm';
                    break;
                case 40:
                    printChar = 'n';
                    break;
                case 41:
                    printChar = 'o';
                    break;
                case 42:
                    printChar = 'p';
                    break;
                case 43:
                    printChar = 'q';
                    break;
                case 44:
                    printChar = 'r';
                    break;
                case 45:
                    printChar = 's';
                    break;
                case 46:
                    printChar = 't';
                    break;
                case 47:
                    printChar = 'u';
                    break;
                case 48:
                    printChar = 'v';
                    break;
                case 49:
                    printChar = 'w';
                    break;
                case 50:
                    printChar = 'x';
                    break;
                case 51:
                    printChar = 'y';
                    break;
                case 52:
                    printChar = 'z';
                    break;
                case 53:
                    printChar = '0';
                    break;
                case 54:
                    printChar = '1';
                    break;
                case 55:
                    printChar = '2';
                    break;
                case 56:
                    printChar = '3';
                    break;
                case 57:
                    printChar = '4';
                    break;
                case 58:
                    printChar = '5';
                    break;
                case 59:
                    printChar = '6';
                    break;
                case 60:
                    printChar = '7';
                    break;
                case 61:
                    printChar = '8';
                    break;
                case 62:
                    printChar = '9';
                    break;
                case 63:
                    printChar = '\n';
                    break;
                default:
                    System.Windows.MessageBox.Show("all the convert number should be between 0-63");
                    break;

            }
            return printChar;
        }
    }
}
