using System;

namespace EMU_8086x_MOV
{
    class Program
    {
        static void Main(string[] args)
        {
            string Text1, tAX = "", tBX = "", tCX = "", rejestr, rejestr_kop;                               //tekstowe wartości rejestrów
            int Option = 0, Rejestr_Conv = 0, Rejestr_Kop = 0;                                              //checki
            int code01 = 0;                                                                                 //sprawdzanie błędu 01
            int code02 = 0;                                                                                 //sprawdzanie błędu 02


            do
            {
                Console.WriteLine("INTEL 8086x MOV Command Emulator");                                      //welcome screen
                Console.WriteLine("To execute MOV command press '1'");
                Console.WriteLine("To exit emulator press '2'");
                Text1 = Console.ReadLine();                                                                 //check
                Int32.TryParse(Text1, out Option);                                                          //int 
                if (Option == 1)                                                                            //if 1 continue 
                {                                                                                           //if 2 exit program
                    Console.WriteLine("Choose register to which you want input value:");                    //zarejestruj kombinacje
                    Console.WriteLine("To choose register AX - press 1");
                    Console.WriteLine("To choose register BX - press 2");
                    Console.WriteLine("To choose register CX - press 3");
                    rejestr = Console.ReadLine();                                                           //check
                    Int32.TryParse(rejestr, out Rejestr_Conv);                                              //int
                    if (Rejestr_Conv == 1)                                                                  //AX
                    {
                        Console.WriteLine("Input value for register AX");
                        tAX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Choose register where you want to copy value to");
                        Console.WriteLine("To choose register BX - press 2");
                        Console.WriteLine("To choose register CS - press 3");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 2)                                                               //BX
                        {
                            tBX = tAX;
                            Console.WriteLine("Executing action - MOV AX BX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 3)                                                               //CX
                        {
                            tCX = tAX;
                            Console.WriteLine("Executing action - MOV AX CX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 2 && Rejestr_Kop != 3)
                            code02 = 1;
                    }
                    if (Rejestr_Conv == 2)                                                                  //BX
                    {
                        Console.WriteLine("Input value for register BX");
                        tBX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Choose register where you want to copy value to");
                        Console.WriteLine("To choose register AX - press 1");
                        Console.WriteLine("To choose register CX - press 3");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 1)                                                               //AX
                        {
                            tAX = tBX;
                            Console.WriteLine("Executing action - MOV BX AX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 3)                                                               //CX
                        {
                            tCX = tBX;
                            Console.WriteLine("Executing action - MOV BX CX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 1 && Rejestr_Kop != 3)
                            code02 = 1;
                    }
                    if (Rejestr_Conv == 3)                                                                  //CX
                    {
                        Console.WriteLine("Input value for register CX");
                        tCX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Choose register where you want to copy value to");
                        Console.WriteLine("To choose register AX - press 1");
                        Console.WriteLine("To choose register BX - press 2");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 1)                                                               //AX
                        {
                            tAX = tCX;
                            Console.WriteLine("Executing action - MOV CX AX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 2)                                                               //BX
                        {
                            tBX = tCX;
                            Console.WriteLine("Executing action - MOV CX BX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 1 && Rejestr_Kop != 2)                                           //check błędu 02
                            code02 = 1;
                    }
                    if (Rejestr_Conv != 1 && Rejestr_Conv != 2 && Rejestr_Conv != 3)                        //ekran błędu 01
                    {
                        code01 = 1;
                        Console.WriteLine("Error #01: Error choosing register. Press any key to continue. . .");
                        Console.ReadKey();
                        code02 = 2;
                        // break;
                    }
                    if (code02 == 1)                                                                        //ekran błędu 02
                    {
                        Console.WriteLine("Error #02: Error choosing register-copy place. Press any key to continue. . .");
                        Console.ReadKey();
                        // break;
                    }
                    Console.WriteLine("Please wait. . .");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Please wait. . .");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Please wait. . .");
                    System.Threading.Thread.Sleep(1000);
                    if (code01 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("MOV command from register complete with success!");
                        Console.ResetColor();
                    }
                    if (code01 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("MOV command from register executed with error.");
                        Console.ResetColor();
                    }
                    if (code02 == 1 || code02 == 2)                                                         //ekran błędu 02
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("MOV command to copy onto register completed with success!");
                        Console.ResetColor();
                    }
                    if (code02 == 0)                                                                        //ekran błędu 02
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("MOV command to register executer without any errors.");
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Register AX after executing MOV command:");
                    Console.WriteLine(tAX);                                                                 //AX 
                    Console.WriteLine("Register BX after executing MOV command:");
                    Console.WriteLine(tBX);                                                                 //BX
                    Console.WriteLine("Register CX after executing MOV command:");
                    Console.WriteLine(tCX);                                                                 //CX
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

            } while (Option != 2);


            //Console.ReadKey();
        }
    }
}
