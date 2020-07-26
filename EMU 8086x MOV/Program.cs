using System;

namespace EMU_8086x_MOV
{
    class Program
    {
        static void Main(string[] args)
        {
            string Text1, tAX = "", tBX = "", tCX = "", rejestr, rejestr_kop;                               //miejsca dla tekstowych wartości rejestrów
            int Option = 0, Rejestr_Conv = 0, Rejestr_Kop = 0;                                              //miejsca na konwersje checków
            int code01 = 0;                                                                                 //Wykrywanie błędu #01
            int code02 = 0;                                                                                 //Wykrywanie błędu #02


            do
            {
                Console.WriteLine("INTEL 8086x MOV Command Emulator");                                      //nazwa programu i wersja
                Console.WriteLine("MOV COMMAND PRESS '1'");
                Console.WriteLine("TO EXIT EMULATOR PRESS '2'");
                Text1 = Console.ReadLine();                                                                 //wartość check
                Int32.TryParse(Text1, out Option);                                                          //konwersja na int
                if (Option == 1)                                                                            //jeśli opcja wynosi 1, program jest kontynuowany,
                {                                                                                           //jeśli opcja jest 2, program się wyłącza    
                    Console.WriteLine("Choose register to which you want input value:");                    //w przeciwnym wypadku program restartuje kombinacje
                    Console.WriteLine("To choose register AX - press 1");
                    Console.WriteLine("To choose register BX - press 2");
                    Console.WriteLine("To choose register CX - press 3");
                    rejestr = Console.ReadLine();                                                           //wartość check
                    Int32.TryParse(rejestr, out Rejestr_Conv);                                              //konwersja na int
                    if (Rejestr_Conv == 1)                                                                  //rejestr AX
                    {
                        Console.WriteLine("Input value for register AX");
                        tAX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Choose register where you want to copy value to");
                        Console.WriteLine("To choose register BX - press 2");
                        Console.WriteLine("To choose register CS - press 3");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 2)                                                               //kopia BX
                        {
                            tBX = tAX;
                            Console.WriteLine("Executing action - MOV AX BX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 3)                                                               //kopia CX
                        {
                            tCX = tAX;
                            Console.WriteLine("Executing action - MOV AX CX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 2 && Rejestr_Kop != 3)
                            code02 = 1;
                    }
                    if (Rejestr_Conv == 2)                                                                  //rejestr BX
                    {
                        Console.WriteLine("Input value for register BX");
                        tBX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Choose register where you want to copy value to");
                        Console.WriteLine("To choose register AX - press 1");
                        Console.WriteLine("To choose register CX - press 3");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 1)                                                               //kopia AX
                        {
                            tAX = tBX;
                            Console.WriteLine("Executing action - MOV BX AX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 3)                                                               //kopia CX
                        {
                            tCX = tBX;
                            Console.WriteLine("Executing action - MOV BX CX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 1 && Rejestr_Kop != 3)
                            code02 = 1;
                    }
                    if (Rejestr_Conv == 3)                                                                  //rejestr CX
                    {
                        Console.WriteLine("Wpisz wartość rejestru CX");
                        tCX = Console.ReadLine();
                        code01 = 0;
                        Console.WriteLine("Wybierz rejestr do którego chcesz skopiować wartość");
                        Console.WriteLine("Aby wybrać rejestr AX - Naciśnij 1");
                        Console.WriteLine("Aby wybrać rejestr BX - Naciśnij 2");
                        rejestr_kop = Console.ReadLine();
                        Int32.TryParse(rejestr_kop, out Rejestr_Kop);
                        if (Rejestr_Kop == 1)                                                               //kopia AX
                        {
                            tAX = tCX;
                            Console.WriteLine("Wykonywanie operacji - MOV CX AX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop == 2)                                                               //kopia BX
                        {
                            tBX = tCX;
                            Console.WriteLine("Wykonywanie operacji - MOV CX BX");
                            code02 = 0;
                        }
                        if (Rejestr_Kop != 1 && Rejestr_Kop != 2)                                           //check dla błędu #02
                            code02 = 1;
                    }
                    if (Rejestr_Conv != 1 && Rejestr_Conv != 2 && Rejestr_Conv != 3)                        //komunikat dla błędu #01
                    {
                        code01 = 1;
                        Console.WriteLine("Error #01: Błąd wyboru rejestru. Naciśnij przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        code02 = 2;
                        // break;
                    }
                    if (code02 == 1)                                                                        //komunikat dla błędu #02
                    {
                        Console.WriteLine("Error #02: Błąd wyboru rejestru-kopii. Naciśnij przycisk aby kontynuować. . .");
                        Console.ReadKey();
                        // break;
                    }
                    Console.WriteLine("Proszę czekać. . .");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Proszę czekać. . .");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Proszę czekać. . .");
                    System.Threading.Thread.Sleep(1000);
                    if (code01 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Operacja zapisu w rejestrze wykonana poprawnie.");
                        Console.ResetColor();
                    }
                    if (code01 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operacja zapisu w rejestrze zakończona niepowodzeniem.");
                        Console.ResetColor();
                    }
                    if (code02 == 1 || code02 == 2)                                                         //komunikat dla błędu #02 c.d.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operacja zapisu kopii w rejestrze zakończona niepowodzeniem.");
                        Console.ResetColor();
                    }
                    if (code02 == 0)                                                                        //komunikat o braku błędu #02 c.d.
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Operacja zapisu kopii w rejestrze wykonana poprawnie.");
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Rejestr AX po wykonaniu operacji:");
                    Console.WriteLine(tAX);                                                                 //wartość AX
                    Console.WriteLine("Rejestr BX po wykonaniu operacji:");
                    Console.WriteLine(tBX);                                                                 //wartość BX
                    Console.WriteLine("Rejestr CX po wykonaniu operacji:");
                    Console.WriteLine(tCX);                                                                 //wartość CX
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

            } while (Option != 2);


            //Console.ReadKey();
        }
    }
}
