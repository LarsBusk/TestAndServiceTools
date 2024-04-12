using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberConverter
{
    class Converters
    {
        static public string DecimalToHex(string decimalString)
        {
            string[] hexNumbers = new string[16] 
                { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            ulong inputNumber = 0;
            string output = "";
            try
            {
                inputNumber = ulong.Parse(decimalString);
            }
            catch (FormatException abc)
            {
                MessageBox.Show(abc.Message);
            }
            catch (OverflowException ovf)
            {
                MessageBox.Show(ovf.Message);
           }
            do
            {
                int rest = (int)(inputNumber % 16);
                inputNumber /= 16;
                output = hexNumbers[rest] + output;
                
            }
            while (inputNumber != 0);
            while (output.Length < 8)
            {
                output = "0" + output;
            }

            return output;
        }

        public static string FiToMosaicChassisID(string fiChassisID)
        {
            if (checkFIChassis(fiChassisID))
            {
                string lowID = fiChassisID.Substring(fiChassisID.IndexOf(",") + 1);
                string highID = fiChassisID.Substring(0, fiChassisID.IndexOf(","));
                string mosaicID = HexToDecimal(DecimalToHex(lowID) + DecimalToHex(highID));
                return mosaicID;
            }
            else return "Error";
        }

        private static bool checkFIChassis(string fiChassisID)
        {
            if (fiChassisID.Contains(","))
            {
                string highID = fiChassisID.Substring(fiChassisID.IndexOf(",") + 1);
                string lowID = fiChassisID.Substring(0, fiChassisID.IndexOf(","));
                try
                {
                    uint nummer = uint.Parse(highID);
                }
                catch (FormatException abc)
                {
                    MessageBox.Show(abc.Message +
                        "\nThe input must consist of 2 numbers between \n0 and 4294967295 and seperated with a ','"
                        , "Wrong Input");
                    return false;
                }
                catch (OverflowException ovf)
                {
                    MessageBox.Show(ovf.Message +
                        "\nThe input must consist of 2 numbers between \n0 and 4294967295 and seperated with a ','"
                        , "Wrong Input");
                    return false;
                }
                try
                {
                    uint nummer = uint.Parse(lowID);
                }
                catch (FormatException abc)
                {
                    MessageBox.Show(abc.Message +
                        "\nThe input must consist of 2 numbers between \n0 and 4294967295 and seperated with a ','"
                        , "Wrong Input");
                    return false;
                }
                catch (OverflowException ovf)
                {
                    MessageBox.Show(ovf.Message +
                        "\nThe input must consist of 2 numbers between \n0 and 4294967295 and seperated with a ','"
                        , "Wrong Input");
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("\nThe input must consist of 2 numbers between \n0 and 4294967295 and seperated with a ','"
                        , "Wrong Input");
                return false;
            }
        }

        public static string MosaicToFiChassisID(string MosaicChassisID)
        {
            string highID, lowID;
            if (checkMosaicID(MosaicChassisID))
            {
                string hexChassisID = DecimalToHex(MosaicChassisID);
                if (hexChassisID.Length > 8)
                {
                    lowID = hexChassisID.Substring(hexChassisID.Length - 8);
                    highID = hexChassisID.Substring(0, hexChassisID.Length - 8);
                }
                else
                {
                    lowID = hexChassisID;
                    highID = "0";
                }
                return string.Format("Low ID: {0} High ID: {1}",HexToDecimal(lowID),HexToDecimal(highID));
            }
            else return "Error";
        }

        private static bool checkMosaicID(string MosaicChassisID)
        {
            try
            {
                ulong number = ulong.Parse(MosaicChassisID);
                return true;
            }
            catch (FormatException abc)
            {
                MessageBox.Show(abc.Message + 
                    "\nThe input must be a number between 0 and 18,446,744,073,709,551,615","Wrong Input");
                return false;
            }
            catch (OverflowException ovf)
            {
                MessageBox.Show(ovf.Message +
                    "\nThe input must be a number between 0 and 18,446,744,073,709,551,615", "Wrong Input");
                return false;
            }
        }




        public static string HexToDecimal(string hexInput)
        {
            long decNumber = 0;
            hexInput = hexInput.ToUpper();

            char[] hexArray = hexInput.ToCharArray();
            foreach (char hexChar in hexArray)
            {
                decNumber *= 16;
                switch (hexChar)
                {
                    case 'F':
                        decNumber += 15;
                        break;
                    case 'E':
                        decNumber += 14;
                        break;
                    case 'D':
                        decNumber += 13;
                        break;
                    case 'C':
                        decNumber += 12;
                        break;
                    case 'B':
                        decNumber += 11;
                        break;
                    case 'A':
                        decNumber += 10;
                        break;
                    default:
                        try
                        {
                            decNumber += long.Parse(hexChar.ToString());
                        }
                        catch (FormatException abc)
                        {
                            MessageBox.Show(abc.Message);
                        }
                        break;
                }

            }
            return decNumber.ToString();
        }
    }
}
