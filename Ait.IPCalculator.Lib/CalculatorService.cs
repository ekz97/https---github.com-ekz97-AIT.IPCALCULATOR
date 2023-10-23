using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Ait.IPCalculator.Lib
{
    public static class CalculatorService
    {

        public static BitArray ConvertByteToBitArray(byte value)
        {
            BitArray bits = new BitArray(8);
            byte[] numbers = new byte[8];
            numbers[0] = 128;
            numbers[1] = 64;
            numbers[2] = 32;
            numbers[3] = 16;
            numbers[4] = 8;
            numbers[5] = 4;
            numbers[6] = 2;
            numbers[7] = 1;


            for (int i = 0; i < 8; i++)
            {
                if (value >= numbers[i])
                {

                    bits.Set(i, true);
                    value -= numbers[i];

                }

                else
                {
                    bits.Set(i, false);
                }
            }

            return bits;


        }


        public static string ConvertByteToStringOfBits(byte value)
        {
            BitArray bits = new BitArray(8);
            string digits = "";
            byte[] numbers = new byte[8];
            numbers[0] = 128;
            numbers[1] = 64;
            numbers[2] = 32;
            numbers[3] = 16;
            numbers[4] = 8;
            numbers[5] = 4;
            numbers[6] = 2;
            numbers[7] = 1;



            for (int i = 0; i < 8; i++)
            {
                if (value >= numbers[i])
                {
                    
                    bits.Set(i, true);
                    digits += "1";
                    value -= numbers[i];

                }

                else
                {
                    bits.Set(i, false);
                    digits += "0";
                }
            }


            return digits;

        } 


        public static string ConvertIPAddressToStringOffBits(IPAddress address)
        {
           
            string digits = "";
            byte[] numbers = new byte[8];
            numbers[0] = 128;
            numbers[1] = 64;
            numbers[2] = 32;
            numbers[3] = 16;
            numbers[4] = 8;
            numbers[5] = 4;
            numbers[6] = 2;
            numbers[7] = 1;


            Byte[] bytes = address.GetAddressBytes();

            for(int a = 0; a < bytes.Length; a++)
            {
                digits += ConvertByteToStringOfBits(bytes[a]);

                #region test
                //for (int i = 0; i < 8; i++)
                //{

                //    if (bytes[a] >= numbers[i])
                //    {


                //        digits += "1";
                //        bytes[a] -= numbers[i];

                //    }

                //    else
                //    {

                //        digits += "0";
                //    }
                //}

                #endregion
            }



            return digits;
        }


        public static string CalculateNetworkAddressFromIpAndCdir(string ipBits,int cdir)
        {
            
            string calculator = "";
            

            for(int i = 0; i < ipBits.Length; i++)
            {
                
                if(i >= cdir)
                {
                    calculator += "0";
                }

                else
                {
                    calculator += ipBits[i];
                }
               
            }


            return calculator;
        }

        public static byte[] ConvertBitsToBytesOffDigits(string bitsInput)
        {


            BitArray bits = new BitArray(32);
            byte[] numbers = new byte[8];
          
            byte[] counter = new byte[4];
          
            numbers[0] = 128;
            numbers[1] = 64;
            numbers[2] = 32;
            numbers[3] = 16;
            numbers[4] = 8;
            numbers[5] = 4;
            numbers[6] = 2;
            numbers[7] = 1;


            int b = 0;
            int b_1;
            int a_1;
            int b_2;
            int a_2;
            int a_3;
            int b_3;


            for (int a = 0; a  < bitsInput.Length; a++)
            {             

                if (a < 8)
                {
                    if(bitsInput[a].ToString() == "1")
                    {
                        counter[b] += numbers[a];
                    }                   
                }

                if(a >= 8 && a < 16)
                {
                    if(bitsInput[a].ToString() == "1")
                    {
                        b_1 = b + 1;

                        a_1 = a - 8;

                        counter[b_1] += numbers[a_1];

                    }                 
                }

                if( a >= 16 && a < 24)
                {
                    if(bitsInput[a].ToString() == "1")
                    {
                        b_2 = b + 2;
                        a_2 = a - 16;

                        counter[b_2] += numbers[a_2];
                    }
                 
                }

                if (a >= 24 && a < 36)
                {
                    if (bitsInput[a].ToString() == "1")
                    {
                        b_3 = b + 3;
                        a_3 = a - 24;

                        counter[b_3] += numbers[a_3];
                    }
                }
            }

            return counter;
           

        }


       public static string CalculateFirstHostAddressInBitsByNetworkAddressInBits(string networkInBits,int cdir)
        {

            string calculator = "";

          

            for (int i = 0; i < networkInBits.Length; i++)
            {

                if(i == 31)
                {
                    calculator += "1";
                }

                else
                {
                    calculator += networkInBits[i];
                }
             
            }

            return calculator;

        }


        public static string ConvertedHostMinInBitsToHostMaxInBits(string hostMinInBits , int cdir)
        {

            string calculator = "";


            for(int i = 0; i < hostMinInBits.Length; i++)
            {
                if(i >= cdir && i < 31)
                {
                    calculator += "1";
                }

                if(i == 31)
                {
                    calculator += "0";
                }

                if(i < cdir)
                {
                    calculator += hostMinInBits[i];
                }
            }

            return calculator;

        }


        public static string FindBroadcastAddress(string lastNetworkAddress)
        {
            string calculator = "";

            for(int i = 0; i < lastNetworkAddress.Length; i++)
            {
                if(i < 31)
                {
                    calculator += lastNetworkAddress[i];
                }
                if(i == 31)
                {
                    calculator += "1";
                }

            }

            return calculator;
        }

        public static double CalculateMaxNumbersOfHosts(int cdir)
        {

            int restingNumberOffBits = 32 - cdir;


            double result = Math.Pow(2, restingNumberOffBits) - 2;

            return result;
            
        }

        public static string CalculateNetworkClassOffIpAddress(string ipInBits)
        {
            string calculator = "";
            byte counter = 0;
            string result = "";

            byte[] numbers = new byte[8];


            #region test
            //numbers[0] = 128;
            //numbers[1] = 64;
            //numbers[2] = 32;
            //numbers[3] = 16;
            //numbers[4] = 8;
            //numbers[5] = 4;
            //numbers[6] = 2;
            //numbers[7] = 1;
            #endregion

            byte[] count = ConvertBitsToBytesOffDigits(ipInBits);

            #region test
            //for(int i = 0; i < count.Length; i++)
            //{

            //}

            //for (int i = 0; i < 8; i++)
            //{
            //    calculator += ipInBits[i];
            //}

            //for(int a=0;  a < calculator.Length; a++)
            //{
            //    if(calculator[a].ToString() == "1")
            //    {
            //        counter += numbers[a];
            //    }
            //}

            #endregion

            if (count[0] >= 0 && count[0] <= 127)
            {
                result = "A";
            }
            if (count[0] >= 128 && count[0] <= 191)
            {
                result = "B";
            }
            if (count[0] >= 192 && count[0] <= 223)
            {
                result = "C";
            }
            if (count[0] >= 224 && count[0] <= 239)
            {
                result = "D";
            }

            if (count[0] >= 240 && count[0] <= 255)
            {
                result = "E";
            }

            return result;
        }

        public static string CheckNetworkTypeIpAddress(string ipInBits)
        {


            byte[] digits = ConvertBitsToBytesOffDigits(ipInBits);

            string result = "";

       
            if(digits[0] == 10 || digits[0] == 172 || digits[0] == 192)
            {
                result = "Private";
            }

            if (digits[0] == 100)
            {
                result = "Shared";
            }

            if (digits[0] == 127)
            {
                result = "Loopback";
            }

            if (digits[0] == 169 && digits[1] == 254)
            {
                result = "Link-Local";
            }

            if (digits[0] == 240 && digits[0] == 255)
            {
                result = "Link-Local";
            }

            if (digits[0] == 240 && digits[0] == 255)
            {
                result = "Link-Local";
            }

            if (digits[0] == 192 && digits[1] == 0 && digits[2] == 2 && digits[3] == 3)
            {
                result = "Test-Net";
            }

            return result;
        }



        public static string ConvertBitsToStringOffDigits(string bitsInput)
        {


            BitArray bits = new BitArray(32);
            byte[] numbers = new byte[8];


            byte[] counter = new byte[4];

            numbers[0] = 128;
            numbers[1] = 64;
            numbers[2] = 32;
            numbers[3] = 16;
            numbers[4] = 8;
            numbers[5] = 4;
            numbers[6] = 2;
            numbers[7] = 1;


            int b = 0;
            int b_1;
            int a_1;
            int b_2;
            int a_2;
            int a_3;
            int b_3;


           byte[] calc =  ConvertBitsToBytesOffDigits(bitsInput);

           string result = $"{calc[0]}.{calc[1]}.{calc[2]}.{calc[3]}";

            #region test2

            //for (int a = 0; a < bitsInput.Length; a++)
            //{



            //    if (a < 8)
            //    {
            //        if (bitsInput[a].ToString() == "1")
            //        {
            //            counter[b] += numbers[a];
            //        }


            //    }

            //    if (a >= 8 && a < 16)
            //    {
            //        if (bitsInput[a].ToString() == "1")
            //        {
            //            b_1 = b + 1;

            //            a_1 = a - 8;

            //            counter[b_1] += numbers[a_1];



            //        }


            //    }

            //    if (a >= 16 && a < 24)
            //    {
            //        if (bitsInput[a].ToString() == "1")
            //        {
            //            b_2 = b + 2;
            //            a_2 = a - 16;

            //            counter[b_2] += numbers[a_2];
            //        }


            //    }

            //    if (a >= 24 && a < 36)
            //    {
            //        if (bitsInput[a].ToString() == "1")
            //        {
            //            b_3 = b + 3;
            //            a_3 = a - 24;

            //            counter[b_3] += numbers[a_3];
            //        }


            //    }
            //}

            //string result = $"{counter[0]}.{counter[1]}.{counter[2]}.{counter[3]}";
            #endregion

            return result;




        }


    }
}
